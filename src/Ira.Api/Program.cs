using Ira.Api.Config;
using Ira.Models.Config;
using Ira.Repositories.Context;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
var config = AppConfiguration.GetConfiguration();

builder.Configuration.AddUserSecrets<Program>();

builder.Logging.ClearProviders();
builder.Host.UseSerilog((hostContext, loggerConfiguration) =>
    loggerConfiguration.ReadFrom.Configuration(hostContext.Configuration));

builder.Services.Configure<EmailConfiguration>(
    builder.Configuration.GetSection("EmailConfiguration"));


AppConfiguration.ConfigureServices(builder.Services, config);

builder.Services.AddControllers();
builder.Services.AddOptions();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<IraContext>();
    db.Database.Migrate();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
