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
        {
            return _context.Seller.ToList();
        }

        public void Insert(Seller obj)
        { // método pra poder exibir um seller, é bem simples no entity framework
            obj.Department = _context.Department.First(); // pra nao bugar o depId
            _context.Add(obj);
            _context.SaveChanges();
        }
    }
}
