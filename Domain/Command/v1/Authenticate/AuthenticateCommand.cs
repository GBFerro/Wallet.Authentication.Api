using MediatR;

namespace Wallet.Authentication.Domain.Command.v1.Authenticate
{
    public partial class AuthenticateCommand : IRequest<AuthenticateCommandResponse>
    {
        public string User { get; set; }
        public string Password { get; set; }
    }
}
