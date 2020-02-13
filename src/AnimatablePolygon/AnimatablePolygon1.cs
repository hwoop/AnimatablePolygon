using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace AnimatablePolygon
{
    [TemplatePart(Name = Segment1PartName, Type = typeof(LineSegment))]
    [TemplatePart(Name = Segment2PartName, Type = typeof(LineSegment))]
    [TemplatePart(Name = Segment3PartName, Type = typeof(LineSegment))]
    [TemplatePart(Name = Segment4PartName, Type = typeof(LineSegment))]
    public sealed class AnimatablePolygon1 : Shape
    {
        public const string Segment1PartName = "PART_Segment1";
        public const string Segment2PartName = "PART_Segment2";
        public const string Segment3PartName = "PART_Segment3";
        public const string Segment4PartName = "PART_Segment4";

        public static readonly DependencyProperty DataProperty = DependencyProperty.Register(
            "Data",
            typeof(Geometry),
            typeof(AnimatablePolygon1),
            new FrameworkPropertyMetadata(
                null,
                FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender),
            null);

        public Geometry Data
        {
            get => (Geometry)GetValue(DataProperty);
            set => SetValue(DataProperty, value);
        }

        public static readonly DependencyProperty PointsProperty = DependencyProperty.Register(
            "Points",
            typeof(PointCollection),
            typeof(AnimatablePolygon1),
            new FrameworkPropertyMetadata(
                null,
                FrameworkPropertyMetadataOptions.AffectsRender,
                new PropertyChangedCallback(OnPointsChangedCallback)));

        public PointCollection Points
        {
            get => (PointCollection)GetValue(PointsProperty);
            set => SetValue(PointsProperty, value);
        }

        public static RoutedEvent PointsChangedEvent = EventManager.RegisterRoutedEvent(
            "PointsChanged",
            RoutingStrategy.Bubble,
            typeof(RoutedEventHandler),
            typeof(AnimatablePolygon1));

        public event RoutedEventHandler PointsChanged
        {
            add { AddHandler(PointsChangedEvent, value); }
            remove { RemoveHandler(PointsChangedEvent, value); }
        }

        static AnimatablePolygon1()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(AnimatablePolygon1),
                new FrameworkPropertyMetadata(typeof(AnimatablePolygon1)));
        }

        private void OnPointsChanged()
        {
            var routedEvent = new RoutedEventArgs(PointsChangedEvent, this);
            RaiseEvent(routedEvent);
        }

        private static void OnPointsChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var polygon = (AnimatablePolygon1)d;
            polygon.OnPointsChanged();
        }

        protected override Geometry DefiningGeometry
        {
            get => Data;
        }
    }
}
