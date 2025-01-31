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

namespace LR3.Wpf.ProductCatalogDesktop_Kharisov_
{
    /// <summary>
    /// Логика взаимодействия для RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        public RegistrationWindow()
        {
            InitializeComponent();
        }

        private void SaveBut_Click(object sender, RoutedEventArgs e)
        {
            string name = NameBox.Text;
            string log = LogBox.Text;
            string pass = PassBox.Text;

            if (name != string.Empty &&
               log != string.Empty &&
               pass != string.Empty)
            {
                bool UserLogin = ApplicationData.users.Any(x => x.Login == log);
                if (UserLogin)
                {
                    MessageBox.Show("Пользователь с таким именем уже существует!", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    return;
                }
                else
                {
                    ApplicationData.users.Add(new Users(ApplicationData.users.Count + 1, name, log, pass));
                    MessageBox.Show("Аккаунт успешно зарегестрирован!", "Успешно", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                    Close();
                }
                
            }
            else
            {
                MessageBox.Show("Одно или несколько полей незаполнены!", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }
        }

        private void OutBut_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
