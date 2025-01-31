using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR7.Wpf.EfCoreRelationsKharisov.Entities
{
    public class Role
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<User> Users { get; set; }
        public List<Permission> Permissions { get; set; }

        public Role() { }
        public Role(
            string title,
            string description)
        {
            Title = title;
            Description = description;
        }
    }
}
