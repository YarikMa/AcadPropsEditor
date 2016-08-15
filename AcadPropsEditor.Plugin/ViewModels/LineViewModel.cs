using AcadPropsEditor.Plugin.DataAccess;
using AcadPropsEditor.Plugin.Models;
using Microsoft.Practices.ServiceLocation;

namespace AcadPropsEditor.Plugin.ViewModels
{
    public class LineViewModel : TreeNodeViewModel
    {
        private readonly Line _line;
        private readonly IShapeRepository<Line> _lineRepository = ServiceLocator.Current.GetInstance<IShapeRepository<Line>>();

        public LineViewModel(Line line, LayerViewModel layer)
            :base(layer)
        {
            _line = line;
        }

        #region Properties

        public string Name => "Линия";

        public double StartX
        {
            get { return _line.StartPoint.X; }
            set
            {
                _line.StartPoint.X = value;
                RaisePropertyChanged();
            }
        }

        public double StartY
        {
            get { return _line.StartPoint.Y; }
            set {
                _line.StartPoint.Y = value;
                RaisePropertyChanged();
            }
        }

        public double StartZ
        {
            get { return _line.StartPoint.Z; }
            set
            {
                _line.StartPoint.Z = value;
                RaisePropertyChanged();
            }
        }

        public double EndX
        {
            get { return _line.EndPoint.X; }
            set
            {
                _line.EndPoint.X = value;
                RaisePropertyChanged();
            }
        }

        public double EndY
        {
            get { return _line.EndPoint.Y; }
            set {
                _line.EndPoint.Y = value;
                RaisePropertyChanged();
            }
        }

        public double EndZ
        {
            get { return _line.EndPoint.Z; }
            set {
                _line.EndPoint.Z = value;
                RaisePropertyChanged();
            }
        }

        #endregion

        public override void Save()
        {
            _lineRepository.Update(_line);
        }
    }
}
