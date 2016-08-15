using AcadPropsEditor.Plugin.DataAccess;
using AcadPropsEditor.Plugin.Models;
using Microsoft.Practices.ServiceLocation;

namespace AcadPropsEditor.Plugin.ViewModels
{
    public class CircleViewModel : TreeNodeViewModel
    {
        private readonly Circle _circle;
        private readonly IShapeRepository<Circle> _circleRepository = ServiceLocator.Current.GetInstance<IShapeRepository<Circle>>();

        public CircleViewModel(Circle circle, LayerViewModel layer)
            :base(layer)
        {
            _circle = circle;
        }

        #region Properties

        public string Name => "Окружность";

        public long Id => _circle.Id;

        public double X
        {
            get { return _circle.Center.X; }
            set
            {
                _circle.Center.X = value;
                RaisePropertyChanged();
            }
        }

        public double Y
        {
            get { return _circle.Center.Y; }
            set
            {
                _circle.Center.Y = value;
                RaisePropertyChanged();
            }
        }

        public double Z
        {
            get { return _circle.Center.Z; }
            set
            {
                _circle.Center.Z = value;
                RaisePropertyChanged();
            }
        }

        public double Radius
        {
            get { return _circle.Radius; }
            set
            {
                _circle.Radius = value;
                RaisePropertyChanged();
            }
        }

        private double _elevation;
        public double Elevation
        {
            get { return _elevation; }
            set { Set(ref _elevation, value); }
        }

        #endregion

        public override void Save()
        {
            _circleRepository.Update(_circle);
        }
    }
}
