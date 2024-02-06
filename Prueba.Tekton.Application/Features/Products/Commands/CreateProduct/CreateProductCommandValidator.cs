using FluentValidation;

namespace Prueba.Tekton.Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty()
                .WithMessage("El campo Name es obligatorio");

            RuleFor(p => p.ProductId)
                .NotEmpty()
                .WithMessage("El campo ProductId es obligatorio");


            RuleFor(p => p.Description)
                .NotEmpty()
                .WithMessage("El campo ProductId es obligatorio");

            RuleFor(p => p.Status)
                    .Must(valor => valor == 0 || valor == 1)
                    .WithMessage("El campo Status debe ser 0 o 1.");

            RuleFor(P => P.Stock)
            .GreaterThanOrEqualTo(0)
            .WithMessage("El campo stock debe ser igual o mayor que cero.");

            RuleFor(P => P.Price)
                .GreaterThan(0)
                .WithMessage("El campo Price debe ser mayor que cero.");

        }
    }
}
