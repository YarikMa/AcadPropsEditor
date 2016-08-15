using System;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;

namespace AcadPropsEditor.Plugin.DataAccess
{
    public class AcadCircleRepository : ShapeRepository<Models.Circle>
    {
        protected override Models.Circle MapFrom(DBObject dbObject)
        {
            var circle = dbObject as Circle;

            return new Models.Circle
            {
                Id = circle.ObjectId.Handle.Value,
                Center = new System.Windows.Media.Media3D.Point3D(circle.Center.X, circle.Center.Y, circle.Center.Z),
                Radius = circle.Radius
            };
        }

        protected override void MapTo(Models.Circle entity, ref DBObject dbObject)
        {
            var c = dbObject as Circle;

            c.Center = new Point3d(entity.Center.X, entity.Center.Y, entity.Center.Z);
            c.Radius = entity.Radius;
        }

        protected override Type AcadType => typeof(Circle);
    }
}
