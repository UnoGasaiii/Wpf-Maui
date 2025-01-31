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
using LR5.Wpf.ElectronicShop_Kharisov_.DatabaseContext;
using LR5.Wpf.ElectronicShop_Kharisov_.Entities;

namespace LR5.Wpf.ElectronicShop_Kharisov_
{
    /// <summary>
    /// Логика взаимодействия для RegWindow.xaml
    /// </summary>
    public partial class RegWindow : Window
    {
        public RegWindow()
        {
            InitializeComponent();
        }
        private void SaveBut_Click(object sender, RoutedEventArgs e)
        {
            string name = NameBox.Text;
            string log = LogBox.Text;
            string pass = PassBox.Text;
            string phone = PhoneBox.Text;

            if (name != string.Empty
                && log != string.Empty
                && pass != string.Empty
                && phone != string.Empty)
            {
                ApplicationDbContext dbContext = new ApplicationDbContext();
                bool isLoginAlreadyExist = dbContext.Users.Any(p => p.Login == log);
                if (isLoginAlreadyExist)
                {
                    MessageBox.Show("Пользователь с данным логином уже существует!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                else
                {
                    UsersEntity user = new UsersEntity(name, log, pass, phone); dbContext.Users.Add(user);
                    dbContext.SaveChanges();

                    MessageBox.Show("Пользователь успешно зарегистрирован!", "Успех", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                    Close();
                }

            }
            else
            {
                MessageBox.Show("Одно или несколько полей незаполнены!", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }
        }


    }
}
