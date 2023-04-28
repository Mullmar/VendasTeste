using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendasBMGTestes.Application.Dtos
{
    public class VendedorDto
    {
        public int Id { get; set; }

        public string Cpf { get; set; }

        public string Nome { get; set; }

        public string Email { get; set; }
        
        [DataType(DataType.PhoneNumber, ErrorMessage = "Telefone inválido")]
        public string Telefone { get; set; }
    }
}
