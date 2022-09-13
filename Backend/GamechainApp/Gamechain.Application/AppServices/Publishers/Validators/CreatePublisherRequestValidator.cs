using FluentValidation;
using Gamechain.Application.Contracts.Requests.Publishers;

namespace Gamechain.Application.AppServices.Publishers.Validators
{
    public class CreatePublisherRequestValidator : AbstractValidator<CreatePublisherRequest>
    {
        public CreatePublisherRequestValidator()
        {
            RuleFor(x => x.Name)
                .MaximumLength(64)
                .NotEmpty();
        }
    }
}
