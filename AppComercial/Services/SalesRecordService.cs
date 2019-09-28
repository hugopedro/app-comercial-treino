using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppComercial.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace AppComercial.Services
{
    public class SalesRecordService
    {
        private readonly AppComercialContext _context;

        public SalesRecordService(AppComercialContext context)
        {
            _context = context;
        }

        public async Task<List<SalesRecord>> FindByDateAsync(DateTime? minDate, DateTime? maxDate)
        { // o ? é pq é opcional ter data minima e maxima
            var result = from obj in _context.SalesRecord select obj; //essa consulta não é executada pela simples definição dela
            if (minDate.HasValue)
            {
                result = result.Where(x => x.Date >= minDate.Value);
            }
            if (maxDate.HasValue)
            {
                result = result.Where(x => x.Date <= maxDate.Value);
            }
            return await result
                .Include(x => x.Seller)
                .Include(x => x.Seller.Department)
                .OrderByDescending(x => x.Date)
                .ToListAsync();
        }

        public async Task<List<IGrouping<Department, SalesRecord>>> FindByDateGroupingAsync(DateTime? minDate, DateTime? maxDate)
        {
            var result = from obj in _context.SalesRecord select obj; //essa consulta não é executada pela simples definição dela
            if (minDate.HasValue)
            {
                result = result.Where(x => x.Date >= minDate.Value);
            }
            if (maxDate.HasValue)
            {
                result = result.Where(x => x.Date <= maxDate.Value);
            }
            return await result
                .Include(x => x.Seller)
                .Include(x => x.Seller.Department)
                .OrderByDescending(x => x.Date) // pra rodar o group by tem q por Task<List<IGrouping<Department,SalesRecord>
                .GroupBy(x => x.Seller.Department) //isso agrupa os resultados usando linq
                .ToListAsync();
        }
    }
}
