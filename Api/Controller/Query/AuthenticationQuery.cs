using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Wallet.Authentication.Api.Controller.Query
{
    public class AuthenticationQuery
    {
        private readonly IMediator _mediator;

        public AuthenticationQuery(IMediator mediator)
        {
            _mediator = mediator;
        }


        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        public async Task<int> RetrieveToken(string name, string email)
            => (int)HttpStatusCode.OK;
        //await _mediator.Send();
    }
}
