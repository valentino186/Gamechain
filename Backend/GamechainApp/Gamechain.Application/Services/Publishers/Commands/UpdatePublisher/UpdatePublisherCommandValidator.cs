using FluentValidation;

namespace Gamechain.Application.Services.Publishers.Commands.UpdatePublisher
{
    public class UpdatePublisherCommandValidator : AbstractValidator<UpdatePublisherCommand>
    {
        public UpdatePublisherCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty();

            RuleFor(x => x.Name)
                .MaximumLength(64)
                .NotEmpty();
        }
    }
}
