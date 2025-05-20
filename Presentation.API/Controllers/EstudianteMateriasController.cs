using Domain.API.DTOs.EstudianteMateria;
using Domain.API.ExceptionHandlers;
using Domain.API.Repositorios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstudianteMateriasController : ControllerBase
    {
        private readonly IMateriaEstudianteRepository _repo;

        public EstudianteMateriasController(IMateriaEstudianteRepository repo)
        {
            _repo = repo;
        }

        [HttpPost]
        public async Task<IActionResult> RegistrarCreditos([FromBody] RegistrarCreditosDTO entity)
        {
            var result = await _repo.RegistrarCreditos(entity);
            if (entity == null)
            {
                throw new  BusinessRuleException("No se pudo crear el credito");
            }
            return Ok(true);
        }
    }
}
