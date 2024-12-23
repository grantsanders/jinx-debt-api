using jinx_debt_api.Data;
using jinx_debt_api.Data.Contexts;
using jinx_debt_api.Endpoints;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddEnvironmentVariables();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Host.UseSerilog(new LoggerConfiguration().WriteTo.Console().CreateLogger());

builder.Services.AddDbContext<GameContext>(options => options.UseNpgsql(builder.Configuration["NEON"]));

builder.Services.AddScoped<PlayerRepository>();
builder.Services.AddScoped<GameRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.MapEndpoints();

app.UseHttpsRedirection();

app.Run();
