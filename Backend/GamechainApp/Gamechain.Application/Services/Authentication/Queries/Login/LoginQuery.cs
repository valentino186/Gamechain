using Gamechain.Application.Common.Responses;
using MediatR;

namespace Gamechain.Application.Services.Authentication.Queries.Login
{
    public record LoginQuery(
        string UserName,
        string Password) : IRequest<LoginResponse>;
}
