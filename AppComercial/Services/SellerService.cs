using AppComercial.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppComercial.Services
{
    public class SellerService
    {
        private readonly AppComercialContext _context;

        public SellerService(AppComercialContext context)
        {
            _context = context;
        }

        public List<Seller> FindAll()
        { // implementar uma operação no Entity Framework pra retornar no banco de dados todos os vendedores
            return _context.Seller.ToList(); // Isso irá acessar a fonte de dados contido na tabela vendedores e converter isso para uma lista
        }

        public void Insert(Seller obj)
        { // método pra poder exibir um seller, é bem simples no entity framework
          //aqui o objeto seller está devidamento instanciado já com o departamento
          //não vou mais precisar pq o objeto seller agora está devidamente instanciado com o departamento! obj.Department = _context.Department.First(); // pra nao bugar o depId
            _context.Add(obj);
            _context.SaveChanges();
        }

        public Seller FindById(int id) // encontrar o vendedor por id
        {
            // aqui é pra ele puxar o ID do vendedor tbm, entao aparece o nome do departamento referente nos detalhes!
            // é assim que se fazer o "eager loading" que significa carregar objetos relacionados ao objeto principal!
            return _context.Seller.Include(obj => obj.Department).FirstOrDefault(obj => obj.Id == id);
        }

        public void Remove(int id)
        {
            var obj = _context.Seller.Find(id);
            _context.Seller.Remove(obj);
            _context.SaveChanges();
        }


    }
}
