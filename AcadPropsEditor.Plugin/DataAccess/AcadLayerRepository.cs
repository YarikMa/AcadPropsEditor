using System;
using System.Collections.Generic;
using System.Windows.Media;
using AcadPropsEditor.Plugin.Models;
using Autodesk.AutoCAD.DatabaseServices;

namespace AcadPropsEditor.Plugin.DataAccess
{
    public class AcadLayerRepository : IRepository<Layer>
    {
        public Layer[] GetAll()
        {
            var db = HostApplicationServices.WorkingDatabase;
            var result = new List<Layer>();

            using (var trans = db.TransactionManager.StartTransaction())
            {
                var layerTable = trans.GetObject(db.LayerTableId, OpenMode.ForRead) as LayerTable;

                if (layerTable == null)
                {
                    throw new InvalidOperationException("Неудается открыть таблицу слоев");
                }

                foreach (var layerId in layerTable)
                {
                    var layerTableRecord = trans.GetObject(layerId, OpenMode.ForRead) as LayerTableRecord;
                    if (layerTableRecord == null) continue;

                    result.Add(new Layer
                    {
                        Id = layerTableRecord.ObjectId.Handle.Value,
                        Name = layerTableRecord.Name,
                        Color = Color.FromRgb(layerTableRecord.Color.ColorValue.R,
                            layerTableRecord.Color.ColorValue.G,
                            layerTableRecord.Color.ColorValue.B),
                        IsOff = layerTableRecord.IsOff
                    });
                }

                trans.Commit();
                return result.ToArray();
            }
        }



        public void Update(Layer entity)
        {
            var db = HostApplicationServices.WorkingDatabase;
            using (var trans = db.TransactionManager.StartTransaction())
            {
                var layerId = db.GetObjectId(false, new Handle(entity.Id), 0);
                var layerTableRecord = trans.GetObject(layerId, OpenMode.ForWrite) as LayerTableRecord;
                if (layerTableRecord == null)
                {
                    throw new InvalidOperationException($"Объект с Id = {entity.Id} не найден");
                }

                layerTableRecord.Name = entity.Name;
                layerTableRecord.Color = Autodesk.AutoCAD.Colors.Color.FromColor(entity.Color);
                layerTableRecord.IsOff = entity.IsOff;

                trans.Commit();
            }
        }
    }
}
