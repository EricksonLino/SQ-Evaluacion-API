using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SQ_Evaluacion_API.Dtos;
using SQ_Evaluacion_API.Models;

namespace SQ_Evaluacion_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormulariosController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public FormulariosController(ApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult> Crear([FromBody] CreacionFormularioDto creacionFormularioDto)
        {
            var formulario = mapper.Map<Formulario>(creacionFormularioDto);
            dbContext.Formularios.Add(formulario);
            await dbContext.SaveChangesAsync();

            return Created("", null);
        }
    }
}
