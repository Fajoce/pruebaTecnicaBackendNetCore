using Domain.API.DTOs.EstudianteMateria;
using Domain.API.Entities;
using Domain.API.Repositorios;
using InfraEstructura.API.DataContext;
using Microsoft.EntityFrameworkCore;

namespace Application.API.Services
{
    public class EstudianteMateriaService : IMateriaEstudianteRepository
    {
        private readonly ColegioDbContext _context;

        public EstudianteMateriaService(ColegioDbContext context)
        {
            _context = context;
        }

        public Task<EstudianteMaterias> RegistrarClases(EstudianteMaterias entity)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> RegistrarCreditos(RegistrarCreditosDTO entity)
        {
            try
            {
                Console.WriteLine("Verificando materias registradas...");
                var materiasRegistradas = await _context.EstudianteMateria
                    .CountAsync(em => em.EstudianteID == entity.EstudianteID);

                if (materiasRegistradas >= 3)
                {
                    throw new InvalidOperationException("El estudiante ya ha registrado el máximo de 3 materias.");
                }

                Console.WriteLine("Verificando si la materia ya fue registrada...");
                var yaRegistrada = await _context.EstudianteMateria
                    .AnyAsync(em => em.EstudianteID == entity.EstudianteID && em.MateriaID == entity.MateriaID);

                if (yaRegistrada)
                {
                    throw new InvalidOperationException("El estudiante ya está inscrito en esta materia.");
                }

                Console.WriteLine("Agregando nueva materia...");

                Console.WriteLine("Agregando nueva materia...");
                var record = new EstudianteMaterias
                {
                    EstudianteID = entity.EstudianteID,
                    MateriaID = entity.MateriaID
                };

                await _context.EstudianteMateria.AddAsync(record);

                Console.WriteLine("Guardando cambios...");
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw new Exception($"Error al registrar créditos: {ex.Message}");
            }
        }
        Task<List<RegistrarCreditosDTO>> IMateriaEstudianteRepository.VerRegistros()
        {
            throw new NotImplementedException();
        }
    }
}
