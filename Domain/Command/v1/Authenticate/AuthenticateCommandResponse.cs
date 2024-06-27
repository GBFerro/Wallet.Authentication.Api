namespace Wallet.Authentication.Domain.Command.v1.Authenticate
{
    public partial class AuthenticateCommandResponse
    {
        public string Email { get; set; }
        public string Token { get; set; }
        public string Name { get; set; }
    }
}
