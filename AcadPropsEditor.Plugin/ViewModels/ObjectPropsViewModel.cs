using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using AcadPropsEditor.Plugin.DataAccess;
using AcadPropsEditor.Plugin.Models;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.Practices.ObjectBuilder2;

namespace AcadPropsEditor.Plugin.ViewModels
{
    public class ObjectPropsViewModel : ViewModelBase, IClosableViewModel
    {
        private readonly IRepository<Layer> _layerRepository;

        public ObjectPropsViewModel(IRepository<Layer> layerRepository)
        {
            _layerRepository = layerRepository;
            LoadLayers();

            _okCommand = new Lazy<RelayCommand>(() => new RelayCommand(Ok));
        }

        public EventHandler ClosingRequest { get; set; }

        #region Properties

        public ObservableCollection<LayerViewModel> Layers { get; } = new ObservableCollection<LayerViewModel>();

        #endregion

        #region Commands

        private readonly Lazy<RelayCommand> _okCommand;
        public ICommand OkCommand => _okCommand.Value;

        private void Ok()
        {
            Layers.ForEach(l => l.Save());
            ClosingRequest?.Invoke(this, null);
        }

        #endregion

        private void LoadLayers()
        {
            var layers = _layerRepository.GetAll();

            foreach (var layer in layers)
            {
                Layers.Add(new LayerViewModel(layer));
            }
        }
    }
}
