using System.ComponentModel.DataAnnotations;

namespace VendasBMGTeste.Domain.Models
{
    public class Venda
    {

        [Key]
        public int Id { get; set; }

        [Required]
        public int IdVendedor { get; set; }

        [Required]
        public int IdStatus { get; set; }

        [Required]
        public DateTime DataPedido { get; set; }

        [Required]
        public List<Produto> Produtos { get; set; } = new List<Produto>();
    }
}
