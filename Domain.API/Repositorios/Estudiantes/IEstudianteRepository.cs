using Domain.API.DTOs;
using Domain.API.DTOs.Estudiantes;

namespace Domain.API.Repositorios.Estudiantes
{
    public interface IEstudianteRepository 
    {
        Task<IEnumerable<VerNombresEstudiantesDTO>> GetEstudiantesPorMateria(int materiaId);
        Task<bool> CrearEstudiante(CrearEstudianteDTO entity);

    }
}
