using Chess.Application.Services.Implementations;
using Chess.Application.Services.Interfaces;
using Chess.Controllers;
using Chess.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IBoardService, BoardService>();
builder.Services.AddScoped<IPieceService, PieceService>();
builder.Services.AddScoped<BoardController>();
builder.Services.AddScoped<PieceController>();

builder.AddInfrastructure();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();