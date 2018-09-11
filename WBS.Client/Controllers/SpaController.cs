using Microsoft.AspNetCore.Mvc;

namespace WBS.Client
{
    public class SpaController : Controller
    {
        public IActionResult Index()
        {
            string browser = Request.Headers["User-Agent"].ToString();
            return View();
        }
    }
}