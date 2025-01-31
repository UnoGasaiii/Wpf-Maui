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
 
    public partial class AddProductWindow : Window
    {
        public AddProductWindow()
        {
            InitializeComponent();
        }
        private void AddProduct(object sender, RoutedEventArgs e)
        {
            string title = TitleTB.Text;
            string description = DescriptionTB.Text;
            string amount = AmountTB.Text;

            bool isTitleEmpty = string.IsNullOrWhiteSpace(title); 
            if (isTitleEmpty)
            {
                MessageBox.Show("Заголовок товара не может быть пустым!", "Ошибка");
                return;
            }

            bool isDescriptionEmpty = string.IsNullOrWhiteSpace(description);
            if (isDescriptionEmpty)
            {
                MessageBox.Show("Описание товара не может быть пустым!", "Ошибка");
                return;
            }

            bool isAmountEmpty = string.IsNullOrWhiteSpace(amount);
            if (isAmountEmpty)
            {
              MessageBox.Show("Количество товара не может быть пустым!", "Ошибка");
              return;
            }
               
            ApplicationDbContext dbContext = new ApplicationDbContext();
            bool isTitleAlreadyExist = dbContext.Products.Any(p => p.Title == title); 
            if (isTitleAlreadyExist)
            {
                MessageBox.Show("Товар с данным заголовком уже существует!", "Ошибка");
                return;

            }
               
           int amounConvertedToInteger = Convert.ToInt32(amount);
           ProductEntity product = new ProductEntity(title, description, amounConvertedToInteger); dbContext.Products.Add(product);
           dbContext.SaveChanges();

           MessageBox.Show("Товар успешно добавлен!", "Успех");
           Close();
        }

        private void closeWindow(object sender, RoutedEventArgs e)
        {
          Close();
        }


    }
}
