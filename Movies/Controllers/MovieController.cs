using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace Movies.Controllers
{
    public class MovieController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Fiction(string author, int views, int ID = 10)
        {
            ViewData["Author"] = author;
            ViewData["Views"] = views;
            ViewData["ID"] = ID;
            return View();
        }
    }
}
