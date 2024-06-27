using MediatR;

namespace Wallet.Authentication.Domain.Command.v1.LogOut
{
    public class LogOutCommandHandler : IRequestHandler<LogOutCommand, LogOutCommandResponse>
    {
        public async Task<LogOutCommandResponse> Handle(LogOutCommand request, CancellationToken cancellationToken)
        {
            return new LogOutCommandResponse();
        }
    }
}
