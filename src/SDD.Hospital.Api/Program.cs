using Microsoft.EntityFrameworkCore;
using SDD.Hospital.Application.Ports;
using SDD.Hospital.Application.UseCases;
using SDD.Hospital.Infrastructure.Events;
using SDD.Hospital.Infrastructure.Persistence;
using SDD.Hospital.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// EF InMemory
builder.Services.AddDbContext<HospitalDbContext>(opt => opt.UseInMemoryDatabase("HospitalDb"));

// DI - application ports
builder.Services.AddScoped<IPatientRepository, PatientRepository>();
builder.Services.AddSingleton<IDomainEventPublisher, ConsoleDomainEventPublisher>();
builder.Services.AddScoped<RegisterPatientUseCase>();

var app = builder.Build();

if (app.Environment.IsDevelopment() || true)
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();
app.UseAuthorization();
app.MapControllers();

app.Run();
