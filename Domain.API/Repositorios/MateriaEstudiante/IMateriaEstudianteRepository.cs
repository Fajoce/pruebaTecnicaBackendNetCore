using Domain.API.DTOs.EstudianteMateria;
using Domain.API.Entities;

namespace Domain.API.Repositorios
{
    public interface IMateriaEstudianteRepository
    {
        Task<List<RegistrarCreditosDTO>> VerRegistros();
        Task<bool> RegistrarCreditos(RegistrarCreditosDTO entity);
        Task<EstudianteMaterias> RegistrarClases(EstudianteMaterias entity);
     
    }
}
