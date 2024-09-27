using jinx_debt_api.Data;
using jinx_debt_api.Data.Contexts;
using jinx_debt_api.Endpoints;
using jinx_debt_api.Models;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Host.UseSerilog(new LoggerConfiguration().WriteTo.Console().CreateLogger());

builder.Services.AddDbContext<DebtContext>(options => options.UseNpgsql(builder.Configuration["ConnectionString"]));

builder.Services.AddScoped<PlayerRepository>();
builder.Services.AddScoped<DebtRepository>();


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
