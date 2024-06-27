using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Wallet.Authentication.Domain.Command.v1.Authenticate;
using Wallet.Authentication.Domain.Command.v1.LogOut;

namespace Wallet.Authentication.Api.Controller.Mutation
{
    public class AuthenticationMutation
    {
        [ProducesResponseType(typeof(AuthenticateCommandResponse), (int)HttpStatusCode.Created)]
        public async Task<AuthenticateCommandResponse> Authenticate(
            [Service] IMediator mediator,
            AuthenticateCommand command,
            CancellationToken cancellationToken
        ) =>
            await mediator.Send(command, cancellationToken);

        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task LogOut(
            [Service] IMediator mediator,
            LogOutCommand command,
            CancellationToken cancellationToken
        ) =>
            await mediator.Send(command, cancellationToken);
    }
}
