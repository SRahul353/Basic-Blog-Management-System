using Basic_Blog_Management_System.Models.Blog;
using Microsoft.EntityFrameworkCore;

namespace Basic_Blog_Management_System.DBContext
{
    public class BlogPostDBContext : DbContext
    {
        public BlogPostDBContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<BlogPost> BlogPost { get; set; }
    }
}
