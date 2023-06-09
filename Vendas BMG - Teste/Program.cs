using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using VendasBMGTeste.Domain.Interfaces;
using VendasBMGTeste.Infra;
using VendasBMGTeste.Infra.DBContext;
using VendasBMGTestes.Application;
using VendasBMGTestes.Application.Dtos;
using VendasBMGTestes.Application.Interfaces;
using VendasBMGTestes.Application.Validators;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services
    .AddControllers()
    .AddFluentValidation(x =>
    {
        x.ImplicitlyValidateChildProperties = true;
        //x.RegisterValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
        
    });

//builder.Services.AddValidatorsFromAssembly(VendaValidator);
builder.Services.AddScoped<IValidator<VendaDto>, VendaDtoValidator>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddDbContext<Contexto>();
builder.Services.AddScoped<IBaseRepository, BaseRepository>();
builder.Services.AddScoped<IVendaRepository, VendaRepository>();
builder.Services.AddScoped<IVendasService, VendasService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
