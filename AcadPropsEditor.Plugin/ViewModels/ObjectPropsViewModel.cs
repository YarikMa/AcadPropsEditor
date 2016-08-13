using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace AcadPropsEditor.Plugin.ViewModels
{
    public class ObjectPropsViewModel : ViewModelBase
    {
        public ObjectPropsViewModel()
        {
            _okCommand = new Lazy<RelayCommand>(() => new RelayCommand(Ok));
        }

        #region Properties

        public ObservableCollection<LayerViewModel> Layers { get; } = new ObservableCollection<LayerViewModel>()
        {
            new LayerViewModel() { Name = "Слой 1", IsVisible = false, Color = Colors.AliceBlue },
            new LayerViewModel() {Name = "Слой 2", IsVisible = true, Color = Colors.Red},
            new LayerViewModel() {Name = "Слой 3", IsVisible = false, Color = Colors.Gray}
        };

        #endregion

        #region Commands

        private readonly Lazy<RelayCommand> _okCommand;
        public ICommand OkCommand => _okCommand.Value;

        private void Ok()
        {
            MessageBox.Show("Hello!");
        }

        #endregion

    }
}
