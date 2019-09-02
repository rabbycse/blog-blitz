using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vue_blog.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() => View();
    }
}
