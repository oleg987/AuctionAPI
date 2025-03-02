using AuctionAPI.Exceptions;
using AuctionAPI.Infrastructure;
using AuctionAPI.Infrastructure.ExceptionHandlers;
using AuctionAPI.Repositories.Abstractions;
using AuctionAPI.Repositories.Implementations;
using AuctionAPI.Services.Abstractions;
using AuctionAPI.Services.Implementations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IDbConnectionFactory, DbConnectionFactory>();

builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

builder.Services.AddTransient<IAuctionService, AuctionService>();

builder.Services.AddTransient<IUserService, UserService>();

builder.Services.AddTransient<ILotService, LotService>();

builder.Services.AddTransient<IBidService, BidService>();

builder.Services.AddExceptionHandler<NotFoundExceptionHandler>();
builder.Services.AddExceptionHandler<CustomValidationExceptionHandler>();
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseExceptionHandler();

app.MapControllers();

app.Run();