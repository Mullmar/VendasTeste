using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VendasBMGTeste.Domain.Models;
using VendasBMGTestes.Application.Dtos;
using VendasBMGTestes.Application.Interfaces;

namespace VendasBMGTeste.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendasController : ControllerBase
    {
        private readonly IVendasService _vendasService;

        public VendasController(IVendasService vendasService)
        {
            _vendasService = vendasService;
        }

        [HttpGet("GetVendaById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var venda = await _vendasService.GetVendaByIdAsync(id);
                if (venda == null) return NoContent();

                return Ok(venda);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar venda. Erro: {ex.Message}");
            }
        }

        [HttpPost]
        [Route("RegistrarVenda")]

        public async Task<IActionResult> Post(VendaDto vendaDto)
        {
            try
            {
                var venda = await _vendasService.AddVenda(vendaDto);
                if (venda == null) return NoContent();

                return Ok(venda);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar registrar venda. Erro: {ex.Message}");
            }
        }

        [HttpPut]
        [Route("AtualizarVenda")]

        public async Task<IActionResult> Put(VendaUpdateDto vendaUpdateDto)
        {
            try
            {
                var venda = await _vendasService.UpdateVenda(vendaUpdateDto);
                if (venda == null) return NoContent();

                return Ok(venda);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar atualizar venda. Erro: {ex.Message}");
            }
        }
    }
}
