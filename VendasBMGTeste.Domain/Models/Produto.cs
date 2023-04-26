using System.ComponentModel.DataAnnotations;

namespace VendasBMGTeste.Domain.Models
{
    public class Produto
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }
    }
}