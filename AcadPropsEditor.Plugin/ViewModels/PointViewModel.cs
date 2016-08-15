using AcadPropsEditor.Plugin.DataAccess;
using AcadPropsEditor.Plugin.Models;
using Microsoft.Practices.ServiceLocation;

namespace AcadPropsEditor.Plugin.ViewModels
{
    public class PointViewModel : TreeNodeViewModel
    {
        private readonly Point _point;
        private readonly IShapeRepository<Point> _pointRepository = ServiceLocator.Current.GetInstance<IShapeRepository<Point>>();

        public PointViewModel(Point point, TreeNodeViewModel parent)
            : base(parent)
        {
            _point = point;
        }

        #region Properties

        public string Name => "Точка";

        public double X
        {
            get { return _point.Center.X; }
            set
            {
                _point.Center.X = value;
                RaisePropertyChanged();
            }
        }

        public double Y
        {
            get { return _point.Center.Y; }
            set
            {
                _point.Center.Y = value;
                RaisePropertyChanged();
            }
        }

        public double Z
        {
            get { return _point.Center.Z; }
            set
            {
                _point.Center.Z = value;
                RaisePropertyChanged();
            }
        }

        #endregion

        public override void Save()
        {
            _pointRepository.Update(_point);
        }
    }
}
