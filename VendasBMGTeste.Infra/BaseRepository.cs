using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendasBMGTeste.Domain.Interfaces;
using VendasBMGTeste.Infra.DBContext;

namespace VendasBMGTeste.Infra
{
    public class BaseRepository : IBaseRepository
    {
        private readonly Contexto _context;

        public BaseRepository(Contexto context)
        {
            _context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.AddAsync(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }
    }
}
