using AutoMapper;
using Gamechain.Application.Common.Responses;
using Gamechain.Application.Interfaces.Repositories;
using MediatR;

namespace Gamechain.Application.Services.Genres.Queries.GetGenres
{
    public class GetGenresQueryHandler : IRequestHandler<GetGenresQuery, List<GenreResponse>>
    {
        private readonly IGenreRepository _genreRepository;
        private readonly IMapper _mapper;

        public GetGenresQueryHandler(IGenreRepository genreRepository, IMapper mapper)
        {
            _genreRepository = genreRepository;
            _mapper = mapper;
        }

        public async Task<List<GenreResponse>> Handle(GetGenresQuery query, CancellationToken cancellationToken)
        {
            var genres = await _genreRepository.GetAll();

            return _mapper.Map<List<GenreResponse>>(genres);
        }
    }
}
