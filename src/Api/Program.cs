using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Wallet.Authentication.Api.Controller.Mutation;
using Wallet.Authentication.Api.Controller.Query;
using Wallet.Authentication.Domain.Command.v1.Authenticate;
using Wallet.Authentication.Domain.Command.v1.LogOut;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "Origins",
                      builder =>
                      {
                          builder.WithOrigins("https://localhost:50000").AllowAnyHeader().AllowAnyMethod();
                      });
});

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(AuthenticateCommand).Assembly, typeof(LogOutCommand).Assembly));

builder.Services.AddValidatorsFromAssemblyContaining<AuthenticateCommandValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<LogOutCommandValidator>();

builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

builder.Services.AddGraphQLServer()
        .AddQueryType<AuthenticationQuery>()
        .AddMutationType<AuthenticationMutation>();

builder.Services.AddAuthentication(cfg =>
    {
        cfg.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        cfg.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        cfg.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    }
)
    .AddJwtBearer(opt =>
        {
            opt.RequireHttpsMetadata = false;
            opt.SaveToken = false;
            opt.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8
                        .GetBytes("gfws65f46e485rf46w2q85r4d2368r42634r246qwsd465as4dc6as5f4ewfw")
                    ),
                ValidateIssuer = false,
                ValidateAudience = false,
                ClockSkew = TimeSpan.Zero
            };
        }
    );

builder.Services.AddGraphQL();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseCors("Origins");

app.MapGraphQL();

app.Run();
