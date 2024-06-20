using Wallet.Authentication.Api.Controller.Mutation;
using Wallet.Authentication.Api.Controller.Query;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();

builder.Services.AddGraphQLServer()
        .AddQueryType<AuthenticationQuery>()
        .AddMutationType<AuthenticationMutation>();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

builder.Services.AddGraphQL();

var app = builder.Build();

app.UseHttpsRedirection();

app.MapControllers();
app.MapGraphQL();

app.Run();
