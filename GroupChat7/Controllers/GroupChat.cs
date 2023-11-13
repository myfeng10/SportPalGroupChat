using Microsoft.AspNetCore.Mvc;

namespace GroupChat7.Controllers
{
    public class GroupChat : Controller
    {
        public IActionResult RegisterEvent()
        {
            return View();
        }
    }
}
