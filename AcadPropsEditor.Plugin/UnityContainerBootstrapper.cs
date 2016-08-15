using AcadPropsEditor.Plugin.DataAccess;
using AcadPropsEditor.Plugin.Models;
using AcadPropsEditor.Plugin.ViewModels;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;

namespace AcadPropsEditor.Plugin
{
    /// <summary>
    /// Загрузчик приложения
    /// </summary>
    internal class UnityContainerBootstrapper
    {
        private readonly UnityContainer _unityContainer;

        public UnityContainerBootstrapper()
        {
            _unityContainer = new UnityContainer();
            RegisterTypes();
            ServiceLocator.SetLocatorProvider(() => new UnityServiceLocator(_unityContainer));
        }

        private void RegisterTypes()
        {
            // ViewModels
            _unityContainer.RegisterType<ObjectPropsViewModel>();

            // Services
            _unityContainer.RegisterType(typeof(IRepository<Layer>), typeof(AcadLayerRepository), new TransientLifetimeManager());
            _unityContainer.RegisterType(typeof(IShapeRepository<Circle>), typeof(AcadCircleRepository), new TransientLifetimeManager());
            _unityContainer.RegisterType(typeof(IShapeRepository<Line>), typeof(AcadLineRepository), new TransientLifetimeManager());
            _unityContainer.RegisterType(typeof(IShapeRepository<Point>), typeof(AcadPointRepository), new TransientLifetimeManager());
        }
    }
}
