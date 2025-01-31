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

namespace LR2.Wpf.WindowCreation_Kharisov_
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        private void InBut_Click(object sender, RoutedEventArgs e)
        {
         MenuWindow menuWindow = new MenuWindow();
            App.Current.MainWindow = menuWindow;
            menuWindow.Show();
            Close();
            
        }


        private void RegBut_Click(object sender, RoutedEventArgs e)
        {
            RegistrationWindow registrationWindow = new RegistrationWindow();
            registrationWindow.ShowDialog();
            
        }
    }
}