using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged([CallerMemberName] string propertyName = "")
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        private PointCollection _points;
        public PointCollection Points
        {
            get => _points;
            set
            {
                _points = value;
                RaisePropertyChanged();
            }
        }

        public KeyTime KeyTime => TimeSpan.FromMilliseconds(100);

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;

            List<PointCollection> collectionList = new List<PointCollection>();

            for (int i = 100; i < 150; i += 5)
            {
                var points = new PointCollection(4)
                {
                    new Point(i, i),
                    new Point(i, 300-i),
                    new Point(300-i, 300-i),
                    new Point(300-i, i)
                };

                points.Freeze();
                collectionList.Add(points);
            }

            Task.Run(() =>
            {
                int cnt = 0;
                while (true)
                {
                    if (cnt >= 10)
                        cnt = 0;

                    Points = collectionList[new Random().Next(0, collectionList.Count)];
                    //Points = collectionList[cnt];

                    cnt++;
                    System.Threading.Thread.Sleep(300);
                }
            });
        }
    }
}
