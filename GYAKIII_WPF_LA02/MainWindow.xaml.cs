using System.Text;
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

namespace GYAKIII_WPF_LA02
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string _BackgroundName = "background.jpg";
        string[] _ImageNames = 
            { "grabowski_1.JPG", "kukori_1.jpg", "kuldonc_1.jpg", "vili_1.jpg" };
        BitmapImage _biBackground;
        BitmapImage[] _biImages = new BitmapImage[8];
        Image[] _imImages;
        Random _rnd = new Random();
        private DispatcherTimer _dt;


        public MainWindow()
        {
            InitializeComponent();

            _imImages = new Image[] { im10, im11, im12, im13,
                                      im20, im21, im22, im23};

            _dt = new DispatcherTimer { 
                Interval = new TimeSpan(0,0,0,0,5000),
                IsEnabled = false
            };

            _dt.Tick += _dt_Tick;
            LoadImages();
            ShowImages();
                
            _dt.Start();

        }

        private void ShowImages()
        {
            for (int i = 0; i < 8; i++)
            {
                _imImages[i].Source = _biImages[i];
            }
        }

        private void LoadImages()
        {
            try
            {
                //háttérkép betöltése
                _biBackground = new BitmapImage(new Uri(@"Images/"
                                + _BackgroundName, UriKind.Relative));
                //képek betöltése
                for (int i = 0; i < 4; i++)
                {
                    _biImages[i] = new BitmapImage(new Uri(@"Images/"
                                + _ImageNames[i], UriKind.Relative));
                    _biImages[i + 4] = _biImages[i];
                }


            }
            catch (Exception)
            {

                MessageBox.Show("A képek nem találhatóak", "Hiba",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void _dt_Tick(object? sender, EventArgs e)
        {
            ShowBackground();
            _dt.Stop();
        }

        private void ShowBackground()
        {
            for (int i = 0; i < 8; i++)
            {
                _imImages[i].Source = _biBackground;
            }
        }
    }
}