using System.Windows;
using AcadPropsEditor.Plugin.ViewModels;

namespace AcadPropsEditor.Plugin.Views
{
    /// <summary>
    /// Логика взаимодействия для ObjectsProps.xaml
    /// </summary>
    public partial class ObjectsProps : Window
    {
        public ObjectsProps()
        {
            InitializeComponent();

            var vm = (IClosableViewModel) DataContext;
            vm.ClosingRequest += (sender, args) =>
            {
                DialogResult = true;
            };
        }
    }
}
