using Andreani.Arq.Observability.Extensions;
using Andreani.Arq.WebHost.Extension;
using Microsoft.AspNetCore.Builder;
using dotnet_socompa_api.Application.Boopstrap;
using dotnet_socompa_api.Infrastructure.Boopstrap;


var builder = WebApplication.CreateBuilder(args);

builder.ConfigureAndreaniWebHost(args);
builder.Services.ConfigureAndreaniServices();
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Host.AddObservability();

var app = builder.Build();

app.UseObservability();
app.ConfigureAndreani();

app.Run();
