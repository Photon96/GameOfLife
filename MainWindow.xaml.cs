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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace GameOfLifeProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ViewModel _VM;
        private DispatcherTimer _Timer;
        private GameProperties _GameProperties;
        public MainWindow()
        {
            InitializeComponent();
            _GameProperties = (GameProperties)TryFindResource("GamePropertiesInstance");
            _VM = new ViewModel();
        }

        void timer_Tick(object sender, EventArgs e)
        {
            _VM.Next();
        }

        void StartBtnClick(object sender, EventArgs e)
        {
            
            NextStateBtn.IsEnabled = false;
            _Timer.Start();
        }

        void StopBtnClick(object sender, EventArgs e)
        {
            _Timer.Stop();
            NextStateBtn.IsEnabled = true;
            
        }

        private void SetTimer()
        {
            int delay = Int32.Parse(System.Configuration.ConfigurationManager.AppSettings.Get("timer"));
            _Timer.Interval = TimeSpan.FromMilliseconds(delay);
            _Timer.Tick += timer_Tick;
            
        }

        private void ChangeCellStateBtn(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            String s = (String)btn.Tag;
            var position = s.Split('_');
            _VM.ChangeCellState(Int32.Parse(position[0]), Int32.Parse(position[1]));
        }

        private void CreateNewGameBtnClick(object sender, RoutedEventArgs e)
        {
            int width, height, degree;
            bool widSet = Int32.TryParse(WidthInput.txtBox.Text, out width);
            bool heightSet = Int32.TryParse(HeightInput.txtBox.Text, out height);
            bool degreeSet = Int32.TryParse(DegreeInput.txtBox.Text, out degree);

            if (widSet && heightSet && degreeSet && _GameProperties.NeighboursToReproduce > 0)
            {
                _VM.CreateNewGame(width, height, degree, _GameProperties);
                this.DataContext = _VM;
                _Timer = new DispatcherTimer();
                SetTimer();
            }
            else
            {
                MessageBox.Show("Podano zle wartosci startowe", "Zle wartosci", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            NextStateBtn.IsEnabled = false;
            
            StartBtn.IsEnabled = true;
            StopBtn.IsEnabled = true;
        }


    }
}
