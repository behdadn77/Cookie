using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult InsertCookie(string value)
        {
            CookieOptions cookieOptions = new CookieOptions();
            cookieOptions.Expires = DateTime.Now.AddSeconds(30);
            Response.Cookies.Append("Mohammadpour", value, cookieOptions);
            ViewData["msg"] = "Cookie Created";
            return View("Index");
        }
        public IActionResult ReadCookie()
        {
            var cookie = Request.Cookies["Mohammadpour"];
            if (cookie == null)
                ViewData["msg"] = "No Cookie or expired";
            else
                ViewData["msg"] = cookie;
            return View("Index");
        }

    }
}
