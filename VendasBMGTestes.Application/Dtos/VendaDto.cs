using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendasBMGTeste.Domain.Models;

namespace VendasBMGTestes.Application.Dtos
{
    public class VendaDto
    {
        public int Id { get; set; }

        public VendedorDto Vendedor { get; set; } = new VendedorDto();

        public string Status { get; set; } = "Aguardando Pagamento";

        public DateTime DataPedido { get; set; }

        public List<ProdutoDto> Produtos { get; set; } = new List<ProdutoDto>();
    }
}
