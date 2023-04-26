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

        [HttpGet]
        [Route("GetVendas")]
        public async Task<IActionResult> Get()
        {
            var venda1 = new VendaDto()
            {
                Id = 1,
                IdStatus = 1,
                IdVendedor = 2,
                DataPedido = DateTime.Now
            };
            var venda2 = new VendaDto()
            {
                Id = 2,
                IdStatus = 1,
                IdVendedor = 3,
                DataPedido = DateTime.Now
            };

            var prod1 = new ProdutoDto()
            {
                Id = 1,
                Nome = ""
            };

            var prod2 = new ProdutoDto()
            {
                Id = 2,
                Nome = "Produto 2"
            };

            var prod3 = new ProdutoDto()
            {
                Id = 3,
                Nome = "Produto 3"
            };
            venda1.Produtos = new List<ProdutoDto>();
            venda1.Produtos.Add(prod1);
            venda1.Produtos.Add(prod2);
            venda1.Produtos.Add(prod3);
            venda2.Produtos = new List<ProdutoDto>();
            venda2.Produtos.Add(prod2);
            venda2.Produtos.Add(prod3);

            List<VendaDto> vendas = new List<VendaDto>();
            vendas.Add(venda1);
            vendas.Add(venda2);

            foreach (var venda in vendas)
            {
                _vendasService.AddVenda(venda);
            }

            return Ok(vendas);
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
    }
}
