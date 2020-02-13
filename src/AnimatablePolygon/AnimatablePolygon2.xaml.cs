using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AnimatablePolygon
{
    /// <summary>
    /// AnimatablePolygon2.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class AnimatablePolygon2 : UserControl
    {
        public static readonly DependencyProperty PointsProperty = DependencyProperty.Register(
            "Points",
            typeof(PointCollection),
            typeof(AnimatablePolygon2));

        public PointCollection Points
        {
            get => (PointCollection)GetValue(PointsProperty);
            set => SetValue(PointsProperty, value);
        }

        public static readonly DependencyProperty KeyTimeProperty = DependencyProperty.Register(
            "KeyTime",
            typeof(KeyTime),
            typeof(AnimatablePolygon2));

        public KeyTime KeyTime
        {
            get => (KeyTime)GetValue(KeyTimeProperty);
            set => SetValue(KeyTimeProperty, value);
        }

        public AnimatablePolygon2()
        {
            InitializeComponent();
        }
    }
}
