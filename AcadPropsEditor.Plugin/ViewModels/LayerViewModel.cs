using System.Windows.Media;
using AcadPropsEditor.Plugin.DataAccess;
using AcadPropsEditor.Plugin.Models;
using Microsoft.Practices.ObjectBuilder2;
using Microsoft.Practices.ServiceLocation;

namespace AcadPropsEditor.Plugin.ViewModels
{
    public class LayerViewModel : TreeNodeViewModel
    {
        private readonly Layer _layer;
        private readonly IRepository<Layer> _layerRepository = ServiceLocator.Current.GetInstance<IRepository<Layer>>();
        private readonly IShapeRepository<Circle> _circleRepository = ServiceLocator.Current.GetInstance<IShapeRepository<Circle>>();
        private readonly IShapeRepository<Line> _lineRepository = ServiceLocator.Current.GetInstance<IShapeRepository<Line>>();
        private readonly IShapeRepository<Point> _pointRepository = ServiceLocator.Current.GetInstance<IShapeRepository<Point>>();

        public LayerViewModel(Layer layer)
            :base(null)
        {
            _layer = layer;
        }

        #region Properties

        public long Id => _layer.Id;

        public string Name
        {
            get { return _layer.Name; }
            set { Set(ref _layer.Name, value); }
        }

        public Color Color
        {
            get { return _layer.Color; }
            set { Set(ref _layer.Color, value); }
        }

        private string _colorText;
        public string ColorText
        {
            get { return Color.ToString(); }
            set
            {
                if (_colorText == value) return;

                _colorText = value;
                var convertFromString = ColorConverter.ConvertFromString(value);
                if (convertFromString != null)
                {
                    Color = (Color)convertFromString;
                    RaisePropertyChanged();
                }
            }
        }

        public bool IsOff
        {
            get { return _layer.IsOff; }
            set { Set(ref _layer.IsOff, value); }
        }

        #endregion

        protected override void LoadChildren()
        {
            var circles = _circleRepository.GetEntitiesByLayerName(_layer.Name);
            circles.ForEach(c => Children.Add(new CircleViewModel(c, this)));

            var lines = _lineRepository.GetEntitiesByLayerName(_layer.Name);
            lines.ForEach(l => Children.Add(new LineViewModel(l, this)));

            var points = _pointRepository.GetEntitiesByLayerName(_layer.Name);
            points.ForEach(p => Children.Add(new PointViewModel(p, this)));
        }

        public override void Save()
        {
            _layerRepository.Update(_layer);
            Children.ForEach(c => c.Save());
        }
    }
}
