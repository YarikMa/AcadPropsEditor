using System;
using System.Windows;
using System.Windows.Input;
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
