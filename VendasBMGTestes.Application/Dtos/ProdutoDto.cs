using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendasBMGTestes.Application.Dtos
{
    public class ProdutoDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório."),
         StringLength(50, MinimumLength = 3,
                          ErrorMessage = "Intervalo permitido de 3 a 50 caracteres.")]
        public string Nome { get; set; }
    }
}
