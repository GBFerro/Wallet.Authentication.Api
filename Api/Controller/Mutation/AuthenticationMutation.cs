using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Wallet.Authentication.Api.Controller.Mutation
{
    public class AuthenticationMutation
    {
        private readonly IMediator _mediator;

        public AuthenticationMutation(IMediator mediator)
        {
            _mediator = mediator;
        }

        [ProducesResponseType(typeof(string), (int)HttpStatusCode.Created)]
        public async Task<int> CreateUser(string name, string email)
            => (int)HttpStatusCode.Created;
        // await _mediator.Send();
    }
}
