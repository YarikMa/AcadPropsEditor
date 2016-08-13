using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;

namespace AcadPropsEditor.Plugin.ViewModels
{
    public class TreeNodeViewModel : ViewModelBase
    {

        #region Properties

        public ObservableCollection<TreeNodeViewModel> Children { get; }

        public TreeNodeViewModel Parent { get; }

        private bool _isExpanded;
        public bool IsExpanded
        {
            get { return _isExpanded; }
            set { Set(ref _isExpanded, value); }
        }

        private bool _isSelected;
        public bool IsSelected
        {
            get { return _isSelected; }
            set { Set(ref _isSelected, value); }
        }

        #endregion

    }
}
