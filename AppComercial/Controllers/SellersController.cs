using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppComercial.Services;
using Microsoft.AspNetCore.Mvc;

namespace AppComercial.Controllers
{
    public class SellersController : Controller
    {
        private readonly SellerService _sellerService;

        public SellersController(SellerService sellerService)
        {
            _sellerService = sellerService;
        }

        public IActionResult Index()
        {
            //implementação da chamada server service .findall
            var list = _sellerService.FindAll();
            return View(list);
        }
    }
}