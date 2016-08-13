using System.Windows.Media.Media3D;

namespace AcadPropsEditor.Plugin.Models
{
    public class Line : Shape
    {
        public Point3D StartPoint { get; set; }
        public Point3D EndPoint { get; set; }
    }
}
