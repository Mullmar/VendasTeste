using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendasBMGTeste.Domain.Models;
using VendasBMGTestes.Application.Dtos;

namespace VendasBMGTestes.Application.Interfaces
{
    public interface IVendasService
    {
        Task<VendaDto> AddVenda(VendaDto model);
        Task<VendaDto> UpdateVenda(VendaUpdateDto model);
        Task<VendaDto> GetVendaByIdAsync(int vendaId);
    }
}
