using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendasBMGTestes.Application.Dtos;

namespace VendasBMGTestes.Application.Validators
{
    public class VendaDtoValidator : AbstractValidator<VendaDto>
    {
        public VendaDtoValidator()
        {
            RuleFor(v => v.Id).GreaterThan(0)
                .WithMessage("Id da venda deve ser maior que 0.");
            RuleFor(v => v.Vendedor.Id).GreaterThan(0)
                .WithMessage("Id do vendedor deve ser maior que 0.");
            RuleFor(v => v.Vendedor.Cpf).NotEmpty()
                .WithMessage("Preencha o cpf do vendedor.");
            RuleFor(v => v.Vendedor.Nome).NotEmpty()
                .WithMessage("Preencha o nome do vendedor.");
            RuleFor(v => v.Vendedor.Email).NotEmpty()
                .WithMessage("Preencha o E-mail.")
                .EmailAddress().WithMessage("E-mail inválido.");
            RuleFor(v => v.Vendedor.Telefone).NotEmpty()
                .WithMessage("Preencha o telefone do vendedor.");
            RuleFor(v => v.Status.ToLower()).Must(x => x == "aguardando pagamento")
                .WithMessage("Status da venda deve ser 'Aguardando Pagamento'");
            RuleFor(v => v.Produtos).NotEmpty()
                .WithMessage("Inclua ao menos 1 produto.");
        }
    }
}
