using System.Windows.Media;
using GalaSoft.MvvmLight;

namespace AcadPropsEditor.Plugin.ViewModels
{
    public class LayerViewModel : TreeNodeViewModel
    {
        #region Properties

        private string _name;

        public string Name
        {
            get { return _name; }
            set { Set(ref _name, value); }
        }

        private Color _color;

        public Color Color
        {
            get { return _color; }
            set { Set(ref _color, value); }
        }

        private bool _isVisible;

        public bool IsVisible
        {
            get { return _isVisible; }
            set { Set(ref _isVisible, value); }
        }

        #endregion

    }
}
