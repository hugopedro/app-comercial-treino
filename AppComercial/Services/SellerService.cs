using AppComercial.Models;
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
    }
}
