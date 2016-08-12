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
        }
    }
}
