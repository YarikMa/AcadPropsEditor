namespace AcadPropsEditor.Plugin.ViewModels
{
    public class LineViewModel : ObjectViewModel
    {
        #region Properties

        private double _startX;
        public double StartX
        {
            get { return _startX; }
            set { Set(ref _startX, value); }
        }

        private double _startY;
        public double StartY
        {
            get { return _startY; }
            set { Set(ref _startY, value); }
        }

        private double _startZ;
        public double StartZ
        {
            get { return _startZ; }
            set { Set(ref _startZ, value); }
        }

        private double _endX;
        public double EndX
        {
            get { return _endX; }
            set { Set(ref _endX, value); }
        }

        private double _endY;
        public double EndY
        {
            get { return _endY; }
            set { Set(ref _endY, value); }
        }

        private double _endZ;
        public double EndZ
        {
            get { return _endZ; }
            set { Set(ref _endZ, value); }
        }

        #endregion
    }
}
