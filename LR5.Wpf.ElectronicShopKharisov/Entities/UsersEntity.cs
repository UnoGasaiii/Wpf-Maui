using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR5.Wpf.ElectronicShop_Kharisov_.Entities
{
    public class UsersEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }

        public UsersEntity() { }
        public UsersEntity(
            string name,
            string login,
            string password,
            string phone)
        {
            Name = name;
            Login = login;
            Password = password;
            Phone = phone;
        }
    }
}
