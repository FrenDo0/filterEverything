using AnualLists.Commands;
using AnualLists.Model;
using AnualLists.View.Windows;
using Microsoft.Extensions.Logging;
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

namespace AnualLists
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

      
        public MainWindow()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void btnSubject_Click(object sender, RoutedEventArgs e)
        {
            var userScreen = new SubjectWindow();
            userScreen.Show();
            this.Close();
        }
        private void btnWine_Click(object sender, RoutedEventArgs e)
        {
            var userScreen = new WineWindow();
            userScreen.Show();
            this.Close();
        }
    }
}