using FluentValidation;

namespace Gamechain.Application.Services.Features.Commands.UpdateFeature
{
    public class UpdateFeatureCommandValidator : AbstractValidator<UpdateFeatureCommand>
    {
        public UpdateFeatureCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty();

            RuleFor(x => x.Name)
                .MaximumLength(32)
                .NotEmpty();
        }
    }
}
