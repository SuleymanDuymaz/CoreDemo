using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
