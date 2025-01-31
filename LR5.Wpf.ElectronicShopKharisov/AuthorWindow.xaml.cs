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
using MySqlConnector;
using LR5.Wpf.ElectronicShop_Kharisov_.DatabaseContext;
using LR5.Wpf.ElectronicShop_Kharisov_.Entities;
using System.Xml.Linq;

namespace LR5.Wpf.ElectronicShop_Kharisov_
{
    /// <summary>
    /// Логика взаимодействия для AuthorWindow.xaml
    /// </summary>
    public partial class AuthorWindow : Window
    {
        public AuthorWindow()
        {
            InitializeComponent();
        }

        private void InBut_Click(object sender, RoutedEventArgs e)
        {
            string log = LogBox.Text;
            string pass = PassBox.Text;

            if (log != string.Empty
                && pass != string.Empty)
            {
                ApplicationDbContext dbContext = new ApplicationDbContext();
                bool isLoginAlreadyExist = dbContext.Users.Any(p => p.Login == log);
                bool isPassAlreadyExist = dbContext.Users.Any(p => p.Password == pass);
                if (isLoginAlreadyExist && isPassAlreadyExist)
                {
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
                    Close();
                }
                else
                {
                    MessageBox.Show("Такого пользователя не существует!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
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
            RegWindow regWindow = new RegWindow();
            regWindow.ShowDialog();
        }
    }
}
