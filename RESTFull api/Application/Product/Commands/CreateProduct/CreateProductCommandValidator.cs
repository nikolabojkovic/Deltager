using FluentValidation;

namespace Application
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(x => x.Name).MaximumLength(100);
            RuleFor(x => x.Type).MaximumLength(50);
        }
    }
}
