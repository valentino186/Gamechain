using FluentValidation;

namespace Gamechain.Application.Services.Platforms.Commands.UpdatePlatform
{
    public class UpdatePlatformCommandValidator : AbstractValidator<UpdatePlatformCommand>
    {
        public UpdatePlatformCommandValidator()
        {
            RuleFor(x => x.Name)
                .MaximumLength(32)
                .NotEmpty();
        }
    }
}
