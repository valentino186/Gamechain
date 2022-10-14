using FluentValidation;

namespace Gamechain.Application.Services.Publishers.Commands.CreatePublisher
{
    public class CreatePublisherCommandValidator : AbstractValidator<CreatePublisherCommand>
    {
        public CreatePublisherCommandValidator()
        {
            RuleFor(x => x.Name)
                .MaximumLength(64)
                .NotEmpty();
        }
    }
}
