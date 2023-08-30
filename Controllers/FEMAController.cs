using Microsoft.AspNetCore.Mvc;

namespace WMVCADS2023.Controllers
{
    public class FEMAController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ADS2()
        {
            return View(); 
        }

    }
}
