using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Configuration;

namespace CoreDemo.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        [AllowAnonymous]
        [Area("Admin")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
