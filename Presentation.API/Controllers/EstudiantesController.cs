using Domain.API.DTOs.Estudiantes;
using Domain.API.Repositorios.Estudiantes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstudiantesController : ControllerBase
    {
        private readonly IEstudianteRepository _repo;

        public EstudiantesController(IEstudianteRepository repo)
        {
            _repo = repo;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> getCourseMates(int id)
        {
            var list = await _repo.GetEstudiantesPorMateria(id);
            if(list == null || !list.Any())
            {
                return NotFound("No hay estudiantes asignados a esta materia");
            }
            return Ok(list);
        }
        [HttpPost]
        public async Task<IActionResult> CrearEstudiante([FromBody] CrearEstudianteDTO entity)
        {
            var result = _repo.CrearEstudiante(entity);
            if(entity is null)
            {
                return BadRequest();
            }
            return Ok(true);
        }
    }
}
