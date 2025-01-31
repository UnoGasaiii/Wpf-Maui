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
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

namespace LR5.Wpf.ElectronicShop_Kharisov_
{

    public partial class EditProductWindow : Window
    {
        private int productId;

        public EditProductWindow(int id)
        {
            InitializeComponent();

            ApplicationDbContext dbContext = new ApplicationDbContext();
            ProductEntity product = dbContext.Products.SingleOrDefault(p => p.Id == id);
            if (product == null)
            {
                MessageBox.Show("Товар с данным идентификатори не найден!", "Ошибка");
                Close();
                return;
            }

            productId = product.Id;
            TitleTB.Text = product.Title;
            DescriptionTB.Text = product.Description;
            AmountTB.Text = product.Amount.ToString();
        }

        private void UpdateProduct(object sender, RoutedEventArgs e)
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

            bool isTitleAlreadyExistForUpdate = dbContext.Products.Any(p => p.Title == title && p.Id != productId);
            if (isTitleAlreadyExistForUpdate)
            {
                MessageBox.Show("Товар с данным заголовком уже существует!", "Ошибка");
                return;
            }

            ProductEntity product = dbContext.Products.SingleOrDefault(p => p.Id == productId);
            if (product == null)
            {
                MessageBox.Show("Товар с данным идентификатором не найден!", "Ошибка");
                Close();
                return;
            }



            int amountConvertedToInteger = Convert.ToInt32(amount);

            product.Title = title;
            product.Description = description;
            product.Amount = amountConvertedToInteger;

            dbContext.Update(product);
            dbContext.SaveChanges();

            MessageBox.Show("Товар успешно обновлён!", "Успех");
            Close();
        }

        private void RemoveProduct(object sender, RoutedEventArgs e)
        {
            ApplicationDbContext dbContext = new ApplicationDbContext();

            ProductEntity product = dbContext.Products.SingleOrDefault(p => p.Id == productId);
            if (product == null)
            {
                MessageBox.Show("Товар с данным идентификатором не найден!", "Ошибка");
                Close();
                return;
            }

            dbContext.Remove(product); 
            dbContext.SaveChanges();

            MessageBox.Show("Товар успешно удалён!", "Успех");
            Close();
            
        }
          private void closeWindow(object sender, RoutedEventArgs e)
          {  
            Close(); 
          }

    }


}

