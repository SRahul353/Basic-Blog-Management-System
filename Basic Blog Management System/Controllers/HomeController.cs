using Basic_Blog_Management_System.DBContext;
using Basic_Blog_Management_System.Models;
using Basic_Blog_Management_System.Models.Blog;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using System.Diagnostics;

namespace Basic_Blog_Management_System.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly BlogPostDBContext _context;


        public HomeController(BlogPostDBContext context, ILogger<HomeController> logger)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> IndexAsync()
        {

            var posts = await _context.BlogPost.ToListAsync();

            return View(posts);
        }


        [HttpPost]
        public async Task<IActionResult> Create(int PostId, string title, string Content, string Author)
        {
            if (PostId == 0)
            {
                var blogPost = new BlogPost
                {
                    Author = Author,
                    Title = title,
                    Content = Content,
                    DateCreated = DateTime.Now
                };
                _context.BlogPost.Add(blogPost);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            else
            {
                var existingPost = await _context.BlogPost.FindAsync(PostId);
                if (existingPost == null)
                {
                    return NotFound(); 
                }
                existingPost.Title = title;
                existingPost.Content = Content;
                existingPost.Author = Author;
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

        }

        [HttpPost]
        public async Task<IActionResult> Delete(int postId)
        {
            var post = await _context.BlogPost.FindAsync(postId);
            if (post == null)
            {
                return NotFound();
            }

            _context.BlogPost.Remove(post);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }    


    }
}
