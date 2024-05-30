using FluentValidation;

namespace DELEGATES
{
    public class ClienteValidator : AbstractValidator<Cliente>
    {
        public ClienteValidator()
        {
            RuleFor(cliente => cliente.Nome).NotEmpty().WithName("Nome do Cliente").WithMessage("O {PropertyName} deve ser preenchido");
            RuleFor(cliente => cliente.SobreNome).NotEmpty().WithName("Sobrenome do Cliente").WithMessage("O {PropertyName} deve ser preenchido");
        }

    }
}
