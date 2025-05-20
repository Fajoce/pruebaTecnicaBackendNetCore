using Application.API.Extensions;
using Application.API.SpecificationService;
using Domain.API.DTOs;
using Domain.API.DTOs.Estudiantes;
using Domain.API.Entities;
using Domain.API.Repositorios.Estudiantes;
using InfraEstructura.API.DataContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.API.Services.Estudiantes
{
    public class EstudianteService : IEstudianteRepository
    {
        private readonly ColegioDbContext _context;

        public EstudianteService(ColegioDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CrearEstudiante(CrearEstudianteDTO entity)
        {
            var student = new Estudiante
            {
                Nombre = entity.Nombre,
                Email = entity.Email,
                PasswordHash = entity.PasswordHash
            };
            await _context.Estudiantes.AddAsync(student);
            _context.SaveChanges();
            return true;

        }

        public async Task<IEnumerable<VerNombresEstudiantesDTO>> GetEstudiantesPorMateria(int estudianteId)
        {
            var spec = new EstudiantesMismaClasePorIdISpecification(estudianteId);
            // Obtener IDs de materias del estudiante
            var materiasDelEstudiante = await(
                from em in _context.EstudianteMateria
                .ApplySpecification(spec)
               // where em.EstudianteID == estudianteId
                select em.MateriaID
            ).ToListAsync();

            //Early Return
            if (!materiasDelEstudiante.Any())
                return Enumerable.Empty<VerNombresEstudiantesDTO>();

            // Obtener compañeros en esas materias (excluyendo al estudiante actual)
            var compañeros = await(
                from em in _context.EstudianteMateria
                join e in _context.Estudiantes on em.EstudianteID equals e.EstudianteID
                join m in _context.Materias on em.MateriaID equals m.MateriaID
                where materiasDelEstudiante.Contains(em.MateriaID)
                      && em.EstudianteID != estudianteId
                select new {
                    Materia = m.Nombre,
                    Estudiante = e.Nombre
                }
            ).ToListAsync();

            // Agrupar por materia
            var resultado = from c in compañeros
                            group c by c.Materia into g
                            select new VerNombresEstudiantesDTO
                            {
                                Materia = g.Key,
                                Companeros = g.Select(x => x.Estudiante).Distinct().ToList()
                            };
            return resultado;
        }
    }
}
    
