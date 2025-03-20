using Microsoft.AspNetCore.Mvc;

namespace AjaxMvc.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
