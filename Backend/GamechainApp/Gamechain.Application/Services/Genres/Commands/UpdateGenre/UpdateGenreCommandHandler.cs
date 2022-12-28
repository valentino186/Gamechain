using AutoMapper;
using Gamechain.Application.Common.Responses;
using Gamechain.Application.Interfaces.Repositories;
using Gamechain.Domain.Entities.Aggregates.Genre;
using Gamechain.Domain.Exceptions;
using MediatR;

namespace Gamechain.Application.Services.Genres.Commands.UpdateGenre
{
    public class UpdateGenreCommandHandler : IRequestHandler<UpdateGenreCommand, GenreResponse>
    {
        private readonly IGenreRepository _genreRepository;
        private readonly IMapper _mapper;

        public UpdateGenreCommandHandler(IGenreRepository genreRepository, IMapper mapper)
        {
            _genreRepository = genreRepository;
            _mapper = mapper;
        }

        public async Task<GenreResponse> Handle(UpdateGenreCommand command, CancellationToken cancellationToken)
        {
            var genre = await _genreRepository.GetById(command.Id);

            if (genre == null)
            {
                throw new EntityNotFoundException(typeof(Genre));
            }

            genre.SetName(command.Name);

            await _genreRepository.Update(genre);

            return _mapper.Map<GenreResponse>(genre);
        }
    }
}
