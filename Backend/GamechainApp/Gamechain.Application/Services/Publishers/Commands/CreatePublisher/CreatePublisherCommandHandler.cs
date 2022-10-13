﻿using AutoMapper;
using Gamechain.Application.Contracts.Common.Responses;
using Gamechain.Application.Contracts.Interfaces.Repositories;
using Gamechain.Domain.Entities.Aggregates.Publisher;
using MediatR;

namespace Gamechain.Application.Services.Publishers.Commands.CreatePublisher
{
    public class CreatePublisherCommandHandler : IRequestHandler<CreatePublisherCommand, PublisherResponse>
    {
        private readonly IRepository<Publisher> _publisherRepository;
        private readonly IMapper _mapper;

        public CreatePublisherCommandHandler(IRepository<Publisher> publisherRepository, IMapper mapper)
        {
            _publisherRepository = publisherRepository;
            _mapper = mapper;
        }

        public async Task<PublisherResponse> Handle(CreatePublisherCommand command, CancellationToken cancellationToken)
        {
            var publisherToCreate = _mapper.Map<Publisher>(command);

            await _publisherRepository.Create(publisherToCreate);

            return _mapper.Map<PublisherResponse>(publisherToCreate);
        }
    }
}
