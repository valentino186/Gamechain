using FluentValidation;

namespace Gamechain.Application.Services.Genres.Commands.UpdateGenre
{
    public class UpdateGenreCommandValidator : AbstractValidator<UpdateGenreCommand>
    {
        public UpdateGenreCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty();

            RuleFor(x => x.Name)
                .MaximumLength(32)
                .NotEmpty();
        }
    }
}
