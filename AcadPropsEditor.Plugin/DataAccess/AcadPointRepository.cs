using System;
using System.Windows.Media.Media3D;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;

namespace AcadPropsEditor.Plugin.DataAccess
{
    public class AcadPointRepository : ShapeRepository<Models.Point>
    {
        protected override Models.Point MapFrom(DBObject dbObject)
        {
            var point = dbObject as DBPoint;

            return new Models.Point
            {
                Id = point.ObjectId.Handle.Value,
                Center = new Point3D(point.Position.X, point.Position.Y, point.Position.Z)
            };
        }

        protected override void MapTo(Models.Point entity, ref DBObject dbObject)
        {
            var p = dbObject as DBPoint;

            p.Position = new Point3d(entity.Center.X, entity.Center.Y, entity.Center.Z);
        }

        protected override Type AcadType => typeof(DBPoint);
    }
}
