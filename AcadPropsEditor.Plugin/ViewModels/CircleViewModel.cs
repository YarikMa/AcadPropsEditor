using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcadPropsEditor.Plugin.ViewModels
{
    public class CircleViewModel : ObjectViewModel
    {
        #region Properties

        private double _x;
        public double X
        {
            get { return _x; }
            set { Set(ref _x, value); }
        }

        private double _y;
        public double Y
        {
            get { return _y; }
            set { Set(ref _y, value); }
        }

        private double _z;
        public double Z
        {
            get { return _z; }
            set { Set(ref _z, value); }
        }

        private double _radius;
        public double Radius
        {
            get { return _radius; }
            set { Set(ref _radius, value); }
        }

        #endregion

    }
}
