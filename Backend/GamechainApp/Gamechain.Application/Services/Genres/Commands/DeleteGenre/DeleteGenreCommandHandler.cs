using Gamechain.Application.Interfaces.Repositories;
using Gamechain.Domain.Entities.Aggregates.Genre;
using Gamechain.Domain.Exceptions;
using MediatR;

namespace Gamechain.Application.Services.Genres.Commands.DeleteGenre
{
    public class DeleteGenreCommandHandler : IRequestHandler<DeleteGenreCommand>
    {
        private readonly IGenreRepository _genreRepository;

        public DeleteGenreCommandHandler(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }

        public async Task<Unit> Handle(DeleteGenreCommand command, CancellationToken cancellationToken)
        {
            var genre = await _genreRepository.GetById(command.Id);

            if (genre == null)
            {
                throw new EntityNotFoundException(typeof(Genre));
            }

            await _genreRepository.Delete(genre);

            return Unit.Value;
        }
    }
}
