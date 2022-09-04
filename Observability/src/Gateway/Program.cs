using LogLibrary.Extensions;
using Gateway.Middlewares;
using Gateway.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Host.AddLog();

builder.Configuration.ConfigureGate();
var gatewayConfig = builder.Configuration.ConfigureSection();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddGateConfiguration(gatewayConfig);

var app = builder.Build();

app.UseLog();
app.UseGateMiddleware();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
