using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;

namespace AcadPropsEditor.Plugin.ViewModels
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
