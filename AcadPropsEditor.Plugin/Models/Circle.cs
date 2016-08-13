using System.Windows.Media.Media3D;

namespace AcadPropsEditor.Plugin.Models
{
    public class Circle : Shape
    {
        public Point3D Center { get; set; }
        public double Radius { get; set; }
    }
}
