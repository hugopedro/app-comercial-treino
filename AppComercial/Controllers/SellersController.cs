using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppComercial.Models;
using AppComercial.Models.ViewModels;
using AppComercial.Services;
using Microsoft.AspNetCore.Mvc;

namespace AppComercial.Controllers
{
    public class SellersController : Controller
    {
        private readonly SellerService _sellerService;
        private readonly DepartmentService _departmentService;

        public SellersController(SellerService sellerService, DepartmentService departmentService)
        {
            _sellerService = sellerService;
            _departmentService = departmentService;
        }

        public IActionResult Index()
        {
            var list = _sellerService.FindAll();
            return View(list);
        }

        public IActionResult Create()
        {
            var departments = _departmentService.FindAll(); // busca no banco todos os departamentos
            var viewModel = new SellerFormViewModel { Departments = departments };
            return View(viewModel); // quando a tela de cadastro for acionada ele ja vai receber os departamentos!
        }

        [HttpPost] // o método de inserir tem q ser post por isso isso ta aqui
        [ValidateAntiForgeryToken]
        public IActionResult Create(Seller seller) // só funfou pq criei no Seller.cs o DepartmentId!
        {
            _sellerService.Insert(seller);
            //redirecionar a requisição pra index(tela principal)
            return RedirectToAction(nameof(Index)); //nameof(Index) melhora a manutenção do sistema pq se algum dia mudar o nome do string da linha 21 nao vai ter que mudar nada!
        }
    }
}