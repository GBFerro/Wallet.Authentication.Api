using MediatR;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Wallet.Authentication.Domain.Command.v1.Authenticate
{
    public class AuthenticateCommandHandler : IRequestHandler<AuthenticateCommand, AuthenticateCommandResponse>
    {
        public async Task<AuthenticateCommandResponse> Handle(AuthenticateCommand request, CancellationToken cancellationToken)
        {

            return new AuthenticateCommandResponse() { Email = "giovani@ferro.com", Name = "giovani", Token = GenerateJWTToken(request) };
        }

        public string GenerateJWTToken(AuthenticateCommand request)
        {
            var claims = new List<Claim> {
                    new Claim(ClaimTypes.NameIdentifier, request.User.ToString())
                };

            var jwtToken = new JwtSecurityToken(
                claims: claims,
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddDays(30),
                signingCredentials: new SigningCredentials(
                    new SymmetricSecurityKey(
                       Encoding.UTF8.GetBytes("gfws65f46e485rf46w2q85r4d2368r42634r246qwsd465as4dc6as5f4ewfw")
                    ),
                    SecurityAlgorithms.Sha256)
                );
            return new JwtSecurityTokenHandler().WriteToken(jwtToken);
        }
    }
}
