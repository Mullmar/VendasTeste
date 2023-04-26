using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendasBMGTeste.Domain.Models;

namespace VendasBMGTeste.Domain.Interfaces
{
    public interface IVendaRepository
    {
        Task<Venda> GetEventoByIdAsync(int id);
    }
}
