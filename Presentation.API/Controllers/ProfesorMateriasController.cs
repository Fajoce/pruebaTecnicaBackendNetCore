using Domain.API.DTOs;
using Domain.API.ExceptionHandlers;
using Domain.API.Repositorios.MateriaProfesor;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfesorMateriasController : ControllerBase
    {
        private readonly IMateriasProfesorRepository _repo;

        public ProfesorMateriasController(IMateriasProfesorRepository repo)
        {
            _repo = repo;
        }

        [HttpPost]
        public async Task<IActionResult> RegistrarClases([FromBody] MateriasProfesorDTO entity)
        {
            var result = await _repo.RegistoDeClases(entity);
            if (!result)
            {
                return BadRequest();
            }
            return Ok(true);
        }

        [HttpGet]
        public async Task<IActionResult> MostrarTodosRegistros()
        {
            var result = await _repo.VerTodosRegistros();
            if(result == null)
            {
                throw new NotFoundException("No hay registros creados");
            }
            return Ok(result);
        }
        [HttpGet("Estudiantes")]
        public async Task<IActionResult> MostrarTodosEstudiantes()
        {
            var result = await _repo.VerTodosEstudiantes();
            if (result == null)
            {
                throw new NotFoundException("No hay estudiantes creados");
            }
            return Ok(result);
        }
        [HttpGet("Profesores")]
        public async Task<IActionResult> MostrarTodosProfesores()
        {
            var result = await _repo.VerTodosProfesores();
            if (result == null)
            {
                throw new NotFoundException("No hay profesores creados");
            }
            return Ok(result);
        }
        [HttpGet("Materias")]
        public async Task<IActionResult> MostrarTodasMaterias()
        {
            var result = await _repo.VerTodosMaterias();
            if (result == null)
            {
                throw new NotFoundException("No hay materias creadas");
            }
            return Ok(result);
        }
    }
}
