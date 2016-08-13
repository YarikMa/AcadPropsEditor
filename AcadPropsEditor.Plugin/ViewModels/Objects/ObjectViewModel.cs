namespace AcadPropsEditor.Plugin.ViewModels.Objects
{
    public class ObjectViewModel : TreeNodeViewModel
    {
        #region Properties

        private string _name;
        public string Name
        {
            get { return _name; }
            set { Set(ref _name, value); }
        }

        private double _elevation;
        public double Elevation
        {
            get { return _elevation; }
            set { Set(ref _elevation, value); }
        }

        #endregion

    }
}
