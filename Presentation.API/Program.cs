using Application.API.Services;
using Application.API.Services.Estudiantes;
using Domain.API.Repositorios;
using Domain.API.Repositorios.Estudiantes;
using Domain.API.Repositorios.MateriaProfesor;
using InfraEstructura.API.DataContext;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ColegioDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddTransient<IEstudianteRepository, EstudianteService>();
builder.Services.AddTransient<IMateriaEstudianteRepository, EstudianteMateriaService>();
builder.Services.AddTransient<IMateriasProfesorRepository, MateriaProfesorSerrvice>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("myPolicies", app =>
    {
        app.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("myPolicies");
app.UseAuthorization();

app.MapControllers();

app.Run();
