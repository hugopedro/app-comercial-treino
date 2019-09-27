using AppComercial.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppComercial.Services
{
    public class DepartmentService //esse serviço vai ter a mesma estrutura de dependencia do SellerService(_context e construtor)
    {
        //readonly previne que essa dependencia nao seja alterada
        private readonly AppComercialContext _context;

        public DepartmentService(AppComercialContext context)
        {
            _context = context;
        }

        //método pra retornar todos os departamentos

        public List<Department> FindAll()
        {
            return _context.Department.OrderBy(x => x.Name).ToList();
        }
    }
}
