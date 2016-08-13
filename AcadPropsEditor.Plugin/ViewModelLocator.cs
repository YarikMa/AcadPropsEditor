/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:MTChat.Client"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using AcadPropsEditor.Plugin.ViewModels;
using AcadPropsEditor.Plugin.ViewModels.Objects;
using Microsoft.Practices.ServiceLocation;

namespace AcadPropsEditor.Plugin
{
    public class ViewModelLocator
    {
        public ObjectPropsViewModel ObjectProps => ServiceLocator.Current.GetInstance<ObjectPropsViewModel>();
        public LayerViewModel Layer => ServiceLocator.Current.GetInstance<LayerViewModel>();
        public PointViewModel Point => ServiceLocator.Current.GetInstance<PointViewModel>();
        public LineViewModel Line => ServiceLocator.Current.GetInstance<LineViewModel>();
        public CircleViewModel Circle => ServiceLocator.Current.GetInstance<CircleViewModel>();

        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}