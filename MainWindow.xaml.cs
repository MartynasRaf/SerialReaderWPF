using System;
using System.Collections.Generic;
using System.IO.Ports;
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

namespace SerialReader
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public SerialMonitor serialMonitor = new SerialMonitor();
        public SerialConfigModel dataContext = new SerialConfigModel();

        public MainWindow()
        {
            DataContext = dataContext;
            InitializeComponent();

            Loaded += MainWindow_Loaded;

        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            parity.ItemsSource = Enum.GetValues(typeof(Parity)).Cast<Parity>();
            handshake.ItemsSource = Enum.GetValues(typeof(Handshake)).Cast<Handshake>();
            stopBits.ItemsSource = Enum.GetValues(typeof(StopBits)).Cast<StopBits>();
        }

        private void Button_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (dataContext.IsOpen)
            {
                serialMonitor.Connect(dataContext);
            } else
            {
                serialMonitor.Disconnect();
            }
        }
    }
}
