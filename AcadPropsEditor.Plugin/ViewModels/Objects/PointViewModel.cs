namespace AcadPropsEditor.Plugin.ViewModels.Objects
{
    public class PointViewModel : ObjectViewModel
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

        #endregion

    }
}
