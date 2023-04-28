using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendasBMGTeste.Domain.Interfaces;
using VendasBMGTeste.Domain.Models;
using VendasBMGTeste.Infra.DBContext;

namespace VendasBMGTeste.Infra
{
    public class VendaRepository : IVendaRepository
    {
        private readonly Contexto _context;
        public VendaRepository(Contexto context)
        {
            _context = context;
        }

        public async Task<Venda> GetVendaByIdAsync(int id)
        {
            IQueryable<Venda> query = _context.Vendas
                .Include(v => v.Vendedor)
                .Include(v => v.Produtos);

            query = query.AsNoTracking().OrderBy(e => e.Id)
                         .Where(e => e.Id == id);

            return await query.FirstOrDefaultAsync();
        }
    }
}
