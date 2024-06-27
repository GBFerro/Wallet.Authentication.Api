using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Wallet.Authentication.Api.Controller.Query
{
    public class AuthenticationQuery
    {
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        public async Task<int> RetrieveToken([Service] IMediator mediator, string name, string email)
            => (int)HttpStatusCode.OK;
        //await mediator.Send();
    }
}
