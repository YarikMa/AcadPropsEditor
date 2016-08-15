using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;

namespace AcadPropsEditor.Plugin.ViewModels
{
    public class TreeNodeViewModel : ViewModelBase
    {
        static readonly TreeNodeViewModel DummyChild = new TreeNodeViewModel();

        protected TreeNodeViewModel(TreeNodeViewModel parent)
        {
            Parent = parent;
            Children = new ObservableCollection<TreeNodeViewModel> {DummyChild};
        }

        private TreeNodeViewModel()
        {
        }

        protected virtual void LoadChildren()
        {
        }

        public virtual void Save()
        { }

        #region Properties

        public ObservableCollection<TreeNodeViewModel> Children { get; }

        public TreeNodeViewModel Parent { get; }

        private bool _isExpanded;
        public bool IsExpanded
        {
            get { return _isExpanded; }
            set
            {
                if (_isExpanded == value) return;

                if (HasDummyChild)
                {
                    Children.Remove(DummyChild);
                    LoadChildren();
                }

                _isExpanded = value;
                RaisePropertyChanged();
            }
        }

        private bool _isSelected;
        public bool IsSelected
        {
            get { return _isSelected; }
            set { Set(ref _isSelected, value); }
        }


        public bool HasDummyChild => this.Children.Count == 1 && this.Children[0] == DummyChild;

        #endregion


    }
}
