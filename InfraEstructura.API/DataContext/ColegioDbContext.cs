using Domain.API.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraEstructura.API.DataContext
{
    public class ColegioDbContext: DbContext
    {
        public ColegioDbContext(DbContextOptions<ColegioDbContext> options): base(options)
        {
            
        }
        public DbSet<Estudiante> Estudiantes { get; set; }
        public DbSet<Profesor> Profesores { get; set; }
        public DbSet<Materia> Materias { get; set; }
        public DbSet<MateriaProfesor> MateriasProfesores { get; set; }
        public DbSet<EstudianteMaterias> EstudianteMateria { get; set; }
    }
}
