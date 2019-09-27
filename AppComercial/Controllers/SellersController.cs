using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppComercial.Models;
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
            var list = _sellerService.FindAll();
            return View(list);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost] // o método de inserir tem q ser post por isso isso ta aqui
        [ValidateAntiForgeryToken]
        public IActionResult Create(Seller seller)
        {
            _sellerService.Insert(seller);
            //redirecionar a requisição pra index(tela principal)
            return RedirectToAction(nameof(Index)); //nameof(Index) melhora a manutenção do sistema pq se algum dia mudar o nome do string da linha 21 nao vai ter que mudar nada!
        }
    }
}