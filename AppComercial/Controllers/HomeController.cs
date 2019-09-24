using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AppComercial.Models;
using AppComercial.Models.ViewModels;

namespace AppComercial.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "App Comercial";
            ViewData["Descricao"] = "Sales MVC App treinamento";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Por Hugo Pedro.";
            ViewData["Email"] = "hugopedro098@gmail.com";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
