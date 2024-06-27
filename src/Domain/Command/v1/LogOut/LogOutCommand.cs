using MediatR;

namespace Wallet.Authentication.Domain.Command.v1.LogOut
{
    public class LogOutCommand : IRequest<LogOutCommandResponse>
    {
    }
}
