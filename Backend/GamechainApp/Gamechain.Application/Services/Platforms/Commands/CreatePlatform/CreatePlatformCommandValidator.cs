using FluentValidation;

namespace Gamechain.Application.Services.Platforms.Commands.CreatePlatform
{
    public class CreatePlatformCommandValidator : AbstractValidator<CreatePlatformCommand>
    {
        public CreatePlatformCommandValidator()
        {
            RuleFor(x => x.Name)
                .MaximumLength(32)
                .NotEmpty();
        }
    }
}
