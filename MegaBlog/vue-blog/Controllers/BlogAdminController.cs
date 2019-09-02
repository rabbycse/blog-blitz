using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vue_blog.Data;
using vue_blog.Models;

namespace vue_blog.Controllers
{
    [Authorize]
    [Route("[controller]/[action]")]
    public class BlogAdminController : Controller
    {
        private AppDbContext _context;
        public BlogAdminController(AppDbContext context)
        {
            _context = context;
        }

       [HttpGet]
       public IActionResult Index() => View(_context.Posts.ToList());

       [HttpPost]
       public async Task<IActionResult> Index(string title, string body)
       {
           _context.Posts.Add(new Post
           {
               Title = title,
               Body = body
           });
           await _context.SaveChangesAsync();
           return RedirectToAction("Index", "BlogAdmin");
       } 
    }
}