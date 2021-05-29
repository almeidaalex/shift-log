using Microsoft.AspNetCore.Mvc;

namespace ShiftLogger.Controllers
{
    public class ShiftController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}