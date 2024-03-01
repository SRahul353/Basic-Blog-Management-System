using static System.Net.Mime.MediaTypeNames;
using System;
using System.ComponentModel.DataAnnotations;

namespace Basic_Blog_Management_System.Models.Blog
{
    public class BlogPost
    {
        [Key]
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
