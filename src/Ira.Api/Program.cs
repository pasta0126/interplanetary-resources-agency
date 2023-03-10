using Ira.Api.Config;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
var configuration = AppConfiguration.GetConfiguration();

builder.Logging.ClearProviders();
builder.Host.UseSerilog((hostContext, loggerConfiguration) =>
    loggerConfiguration.ReadFrom.Configuration(hostContext.Configuration));

AppConfiguration.ConfigureServices(builder.Services);

builder.Services.AddControllers();
builder.Services.AddOptions();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
