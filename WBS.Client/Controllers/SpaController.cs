using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WBS.Client.Controllers
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