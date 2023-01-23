using FluentValidation;

namespace Gamechain.Application.Services.Features.Commands.CreateFeature
{
    public class CreateFeatureCommandValidator : AbstractValidator<CreateFeatureCommand>
    {
        public CreateFeatureCommandValidator()
        {
            RuleFor(x => x.Name)
                .MaximumLength(32)
                .NotEmpty();
        }
    }
}
