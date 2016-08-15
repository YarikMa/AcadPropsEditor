using System;
using System.Collections.Generic;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;

namespace AcadPropsEditor.Plugin.DataAccess
{
    public abstract class ShapeRepository<TEntity> : IShapeRepository<TEntity> 
        where TEntity : Models.Entity
    {
        public TEntity[] GetAll()
        {
            var db = HostApplicationServices.WorkingDatabase;

            // начинаем транзакцию
            using (var tr = db.TransactionManager.StartTransaction())
            {
                // получаем ссылку на пространство модели (ModelSpace)
                var ms = (BlockTableRecord)tr.GetObject(SymbolUtilityServices.GetBlockModelSpaceId(db), OpenMode.ForRead);

                // "пробегаем" по всем объектам в пространстве модели
                var result = new List<TEntity>();
                foreach (var id in ms)
                {
                    // приводим каждый из них к типу TEntity
                    var dbObject = tr.GetObject(id, OpenMode.ForRead);
                    if (dbObject != null && dbObject.GetType() != AcadType) continue;

                    result.Add(MapFrom(dbObject));
                }

                tr.Commit();
                return result.ToArray();
            }
        }

        public void Update(TEntity entity)
        {
            var db = HostApplicationServices.WorkingDatabase;

            using (var tr = db.TransactionManager.StartTransaction())
            {
                var objectId = db.GetObjectId(false, new Handle(entity.Id), 0);
                var obj = tr.GetObject(objectId, OpenMode.ForWrite);

                if (obj == null)
                {
                    throw new InvalidOperationException($"Объект с Id = {entity.Id} не найден");
                }

                MapTo(entity, ref obj);

                tr.Commit();
            }
        }

        public TEntity[] GetEntitiesByLayerName(string layerName)
        {
            var doc = Application.DocumentManager.MdiActiveDocument;
            var db = HostApplicationServices.WorkingDatabase;
            var ed = doc.Editor;

            // Build a filter list so that only entities
            // on the specified entity are selected
            var tvs = new[]
            {
                new TypedValue((int)DxfCode.LayerName, layerName)

            };
            var sf = new SelectionFilter(tvs);
            var psr = ed.SelectAll(sf);

            var result = new List<TEntity>();

            if (psr.Status != PromptStatus.OK) return result.ToArray();

            using (var tr = db.TransactionManager.StartTransaction())
            {
                foreach (ObjectId id in new ObjectIdCollection(psr.Value.GetObjectIds()))
                {
                    var dbObject = tr.GetObject(id, OpenMode.ForRead);
                    if (dbObject != null && dbObject.GetType() != AcadType) continue;

                    result.Add(MapFrom(dbObject));
                }

                tr.Commit();
                return result.ToArray();
            }
        }

        protected abstract TEntity MapFrom(DBObject dbObject);
        protected abstract void MapTo(TEntity entity, ref DBObject dbObject);
        protected abstract Type AcadType { get; }
    }
}
