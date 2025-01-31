using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LR7.Wpf.EfCoreRelationsKharisov.Entities
{
    public class Note
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedAt   { get; set; }
        public DateTime? UpdateAt { get; set; }
        public User User { get; set; }

        public Note() { }
        public Note(
            int userid,
            string title,
            string? description)
        {
            UserId = userid;
            Title = title;
            Description = description;
            CreatedAt = DateTime.Now;
        }
    }
}
