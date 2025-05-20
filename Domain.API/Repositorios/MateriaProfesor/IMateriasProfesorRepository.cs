using Domain.API.DTOs;
using Domain.API.DTOs.MateriasProfesor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.API.Repositorios.MateriaProfesor
{
    public interface IMateriasProfesorRepository
    {
        Task<bool> RegistoDeClases(MateriasProfesorDTO entity);
        Task<List<VerRegistrosDTO>> VerTodosRegistros();
        Task<List<SelectMateriasDTO>> VerTodosMaterias();
        Task<List<SelectProfesoresDTO>> VerTodosProfesores();
        Task<List<SelectEstudiantesDTO>> VerTodosEstudiantes();
    }
}
