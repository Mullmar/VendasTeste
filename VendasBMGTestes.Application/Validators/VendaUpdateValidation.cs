using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendasBMGTeste.Domain.Models;

namespace VendasBMGTestes.Application.Validators
{
    public class VendaUpdateValidation
    {
        private readonly string _statusAtual;
        private readonly string _statusNovo;
        private readonly Venda _venda;
        private bool _result = true;
        public VendaUpdateValidation(string statusAtual, string statusNovo) { 
            _statusAtual = statusAtual;
            _statusNovo = statusNovo;
        }

        public VendaUpdateValidation(Venda venda)
        {
            _venda = venda;
        }

        public bool IsValidUpdate() {
            switch(_statusAtual.ToLower())
            {
                case "aguardando pagamento":
                    _result = _statusNovo.ToLower() == "pagamento aprovado" || _statusNovo.ToLower() == "cancelada" ? true : false;
                    break;
                
                case "pagamento aprovado":
                    _result = _statusNovo.ToLower() == "enviado para transportadora" || _statusNovo.ToLower() == "cancelada" ? true : false;
                    break;

                case "enviado para transportadora":
                    _result = _statusNovo.ToLower() == "entregue" ? true : false;
                    break;
            }
            return _result;
        }

        public bool IsValidAdd()
        {
            var resultado = false;

            if (_venda.Status.ToLower() == "aguardando pagamento" && _venda.Produtos.Count >= 1)
                resultado = true;

            return resultado;
        }
    }
}
