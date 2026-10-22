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

namespace _01_task
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private UDPClients client = new UDPClients();
        public MainWindow()
        {
            InitializeComponent();
            MyIP.Text = "127.0.0.1";
            MyPort.Text = "8080";
        }

        private void Send_Button(object sender, RoutedEventArgs e)
        {
            string message = MytextBox.Text;

            if (string.IsNullOrEmpty(message))
            {
                ListServer.Items.Add("Please repeat!!!");
                return;
            }

            ListClient.Items.Add(message);
            MytextBox.Clear();

            try
            {
                string response = client.Talk(message);
                ListServer.Items.Add(response);
            }
            catch (Exception ex)
            {
                ListServer.Items.Add(ex.Message);
            }
        }
    }
}