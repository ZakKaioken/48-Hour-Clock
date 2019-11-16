using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace _48_Hour_Clock
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer UpdateTimer = new DispatcherTimer();

        StringBuilder sb = new StringBuilder();
        public int HourMax = 48;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Label_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateTimer.Interval = new TimeSpan(0, 0, 0, 1);
            UpdateTimer.Tick += (y,v) => DoUpdate();
            UpdateTimer.Start();
        }

        private void DoUpdate()
        {
            TimeText.Content = GetTime();
        }

        private string GetTime()
        {
            sb.Clear();

            DateTime now = DateTime.Now;
            var DayOfWeek = (int)now.DayOfWeek;

            int WeekProgress = DayOfWeek * 24 * 3600000;
            var DayProgress = (now - DateTime.Today).TotalMilliseconds;

            var TotalProgress = WeekProgress + DayProgress;

            var Hour = (TotalProgress / 3600000) % HourMax;
            var Minute = (Hour - Math.Floor(Hour)) * 60;

            sb.Append(Math.Floor(Hour));
            sb.Append(":");
            sb.Append(FillEmpty(Math.Floor(Minute)));
            return sb.ToString();
        }

        string FillEmpty(double o)
        {
            if (o < 10) return "0" + o;
            return "" + o;
        }
    }
}
