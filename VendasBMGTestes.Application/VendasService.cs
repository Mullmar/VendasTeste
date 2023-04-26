using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using VendasBMGTeste.Domain.Models;
using VendasBMGTeste.Infra.DBContext;
using VendasBMGTestes.Application.Dtos;
using VendasBMGTestes.Application.Interfaces;
using AutoMapper;
using VendasBMGTeste.Domain.Interfaces;

namespace VendasBMGTestes.Application
{
    public class VendasService : IVendasService
    {
        private readonly Contexto _context;
        private readonly IMapper _mapper;
        private readonly IVendaRepository _vendaRepo;
        private readonly IBaseRepository _baseRepo;

        public VendasService(Contexto context, IMapper mapper, IVendaRepository vendaRepo, IBaseRepository baseRepo)
        {
            _context = context;
            _mapper = mapper;
            _vendaRepo = vendaRepo;
            _baseRepo = baseRepo;
        }

        public async Task<VendaDto> AddVenda(VendaDto model) {

            try
            {
                var venda = _mapper.Map<Venda>(model);
                venda.Id = model.Id;

                _baseRepo.Add<Venda>(venda);

                if (await _baseRepo.SaveChangesAsync())
                {
                    var vendaRetorno = await _vendaRepo.GetEventoByIdAsync(venda.Id);

                    return _mapper.Map<VendaDto>(vendaRetorno);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            //return Task.FromResult(model);
        }
        public Task<VendaDto> UpdateVenda(VendaDto model) {
            return Task.FromResult(model);
        }
        public async Task<VendaDto> GetVendaByIdAsync(int vendaId) {
            try
            {
                var venda = await _vendaRepo.GetEventoByIdAsync(vendaId);
                if (venda == null) return null;

                var resultado = _mapper.Map<VendaDto>(venda);

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}