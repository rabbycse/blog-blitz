using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using vue_blog.Data;
using vue_blog.Models;

namespace vue_blog.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BlogController : Controller
    {
        private AppDbContext _context;
        public BlogController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Post> GetPosts() => _context.Posts.ToList();

        [HttpGet("{id}")]
        public Post GetPost(int id) => _context.Posts.First(x => x.Id == id);

    }
}