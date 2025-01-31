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
using System.Xml.Linq;

namespace LR3.Wpf.ProductCatalogDesktop_Kharisov_
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
            string log = LogBox.Text;
            string pass = PassBox.Text;

            if (log != string.Empty &&
               pass != string.Empty)
            {
                bool UserLogin = ApplicationData.users.Any(x => x.Login == log);
                bool UserPass = ApplicationData.users.Any(x => x.Password == pass);
                if (UserLogin && UserPass)
                {
                    MenuWindow menuWindow = new MenuWindow();
                    App.Current.MainWindow = menuWindow;
                    menuWindow.Show();
                    Close();
                }
                else
                {
                    MessageBox.Show("Данный пользователь не найден", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

            }
            else
            {
                MessageBox.Show("Одно или несколько полей незаполнены!", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }
        }


        private void RegBut_Click(object sender, RoutedEventArgs e)
        {
            RegistrationWindow registrationWindow = new RegistrationWindow();
            registrationWindow.ShowDialog();

        }
    }
}