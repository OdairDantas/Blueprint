using $safeprojectname$.Validations;
using TemplateWebAPI.Domain.Messages;

namespace $safeprojectname$.Commands
{
    public class AdicionarProdutoCommand : Command
    {

        public AdicionarProdutoCommand(string descricao, decimal valor)
        {
            Descricao = descricao;
            Valor = valor;
        }

        public string Descricao { get; private set; }
        public decimal Valor { get; private set; }

        public override bool EhValido()
        {
            ValidationResult = new AdicionarProdutoValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
