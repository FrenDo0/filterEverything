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
using System.Windows.Shapes;

namespace AnualLists.View.Windows
{
    /// <summary>
    /// Interaction logic for WineWindow.xaml
    /// </summary>
    public partial class WineWindow : Window
    {
        public WineWindow()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }
        private void btnGoBack_Click(object sender, RoutedEventArgs e)
        {
            var userScreen = new MainWindow();
            userScreen.Show();
            this.Hide();
        }
    }
}
