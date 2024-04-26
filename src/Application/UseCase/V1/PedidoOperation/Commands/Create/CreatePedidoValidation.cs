using dotnet_socompa_api.Application.UseCase.V1.PersonOperation.Commands.Create;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnet_socompa_api.Application.UseCase.V1.PedidoOperation.Commands.Create
{
    
    public class CreatePedidoValidation : AbstractValidator<CreatePedidoCommand>
    {
        public CreatePedidoValidation()
        {
            RuleFor(x => x.cuentaCorriente)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("La cuenta corriente debe informarse de modo obligatorio.-");
            RuleFor(x => x.cuentaCorriente)
                .Custom((cuenta, context) =>
                {
                    if (! cuenta.All(char.IsDigit))
                        context.AddFailure("Deben especificarse sólo números para la cuenta corriente.-");
                });
            RuleFor(x => x.codigoDeContratoInterno)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("El código de contrato debe informarse de modo obligatorio.-");
            RuleFor(x => x.codigoDeContratoInterno)
                .Custom((contrato, context) =>
                {
                    if (!long.TryParse(contrato.ToString(), out _))
                        context.AddFailure("El valor del contrato no es válido: o no es numérico o supera el máximo permitido (9.223.372.036.854.775.807).-");
                });

        }
    }
}
