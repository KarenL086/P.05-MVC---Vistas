using Microsoft.AspNetCore.Mvc;

namespace PracticaMVC.Controllers
{
    public class equipoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
