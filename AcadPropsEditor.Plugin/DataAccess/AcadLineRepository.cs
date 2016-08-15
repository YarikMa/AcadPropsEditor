using System;
using System.Windows.Media.Media3D;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;

namespace AcadPropsEditor.Plugin.DataAccess
{
    public class AcadLineRepository : ShapeRepository<Models.Line>
    {
        protected override Models.Line MapFrom(DBObject dbObject)
        {
            var line = dbObject as Line;

            return new Models.Line
            {
                Id = line.ObjectId.Handle.Value,
                StartPoint = new Point3D(line.StartPoint.X, line.StartPoint.Y, line.StartPoint.Z),
                EndPoint = new Point3D(line.EndPoint.X, line.EndPoint.Y, line.EndPoint.Z)
            };
        }

        protected override void MapTo(Models.Line entity, ref DBObject dbObject)
        {
            var l = dbObject as Line;

            l.StartPoint = new Point3d(entity.StartPoint.X, entity.StartPoint.Y, entity.StartPoint.Z);
            l.EndPoint = new Point3d(entity.EndPoint.X, entity.EndPoint.Y, entity.EndPoint.Z);
        }

        protected override Type AcadType => typeof(Line);
    }
}
