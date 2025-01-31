using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR3.Wpf.ProductCatalogDesktop_Kharisov_
{
    public class Users
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public Users(int id,string name,string login, string password) 
        { 
            Id = id;
            Name = name;
            Login = login;
            Password = password;
        }


    }
}
