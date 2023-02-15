using FluentValidation;

namespace Gamechain.Application.Services.Games.Commands.UpdateGame
{
    public class UpdateGameCommandValidator : AbstractValidator<UpdateGameCommand>
    {
        public UpdateGameCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty();

            RuleFor(x => x.PublisherId)
                .NotEmpty();

            RuleFor(x => x.Name)
                .MaximumLength(64)
                .NotEmpty();

            RuleFor(x => x.Description)
                .MaximumLength(512)
                .NotEmpty();

            RuleFor(x => x.Price)
                .NotEmpty();

            RuleFor(x => x.Discount)
                .NotNull();
        }
    }
}
