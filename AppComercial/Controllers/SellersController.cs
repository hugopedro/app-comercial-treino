﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppComercial.Models;
using AppComercial.Models.ViewModels;
using AppComercial.Services;
using Microsoft.AspNetCore.Mvc;
using AppComercial.Services.Exceptions;

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

        public IActionResult Delete(int? id) //o ? significa que o int é opcional
        {
            if (id == null) // se o id for nulo quer dizer que a requisição foi feita de uma forma indevida
            {
                return NotFound(); // deixar o notefound sem nada gera uma pagina de erro basica
            }

            var obj = _sellerService.FindById(id.Value); // tem q por .value pq ele é um nullable(objeto opcional) 
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id) // esse método é pro botao de delete funfar
        {
            _sellerService.Remove(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int? id)
        {

            if (id == null) // se o id for nulo quer dizer que a requisição foi feita de uma forma indevida
            {
                return NotFound(); // deixar o notefound sem nada gera uma pagina de erro basica
            }

            var obj = _sellerService.FindById(id.Value); // tem q por .value pq ele é um nullable(objeto opcional) 
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null) // se o id for nulo quer dizer que a requisição foi feita de uma forma indevida
            {
                return NotFound(); // deixar o notefound sem nada gera uma pagina de erro basica
            }

            var obj = _sellerService.FindById(id.Value);
            if (obj == null)
            {
                return NotFound();
            }

            List<Department> departments = _departmentService.FindAll();
            SellerFormViewModel viewModel = new SellerFormViewModel { Seller = obj, Departments = departments }; // instanciação do viewmodel
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Seller seller) // tambem recebe o objeto seller
        { // isso é pro botão de edição funfar
            if (id != seller.Id) // se o id for diferente do id do vendedor algo está errado
            {
                return BadRequest();
            }
            try
            {
                _sellerService.Update(seller);
                return RedirectToAction(nameof(Index));
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
            catch (DbConcurrencyException)
            {
                return BadRequest();
            }
        }
    }
}