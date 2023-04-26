using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendasBMGTestes.Application.Dtos
{
    public class VendaDto
    {
        public int Id { get; set; }

        public int IdVendedor { get; set; }

        public int IdStatus { get; set; }

        public DateTime DataPedido { get; set; }

        public List<ProdutoDto>? Produtos { get; set; }
    }
}
