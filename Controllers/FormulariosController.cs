using AutoMapper;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        private readonly DapperDbContext dapperDbContext;

        public FormulariosController(ApplicationDbContext dbContext, IMapper mapper, DapperDbContext dapperDbContext)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
            this.dapperDbContext = dapperDbContext;
        }

        [HttpPost]
        public async Task<ActionResult> Crear([FromBody] CreacionFormularioDto creacionFormularioDto)
        {
            var formulario = mapper.Map<Formulario>(creacionFormularioDto);
            dbContext.Formularios.Add(formulario);
            await dbContext.SaveChangesAsync();

            return Created("", null);
        }

        [HttpGet]
        public async Task<ActionResult<List<FormularioDto>>> ListarFormularios()
        {
            var formularios = await dbContext.Formularios.ToListAsync();
            var formulariosDto = mapper.Map<List<FormularioDto>>(formularios);

            return formulariosDto;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DetalleFormularioDto>> ObtenerFormularioPorId([FromRoute] int id)
        {
            var formulario = await dbContext.Formularios.FirstOrDefaultAsync(x => x.Id == id);
            if (formulario == null)
            {
                return NotFound();
            }

            var detalleFormularioDto = mapper.Map<DetalleFormularioDto>(formulario);
            return detalleFormularioDto;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Editar([FromRoute] int id, [FromBody] EditarFormularioDto editarFormularioDto)
        {
            var formularioModels = await dbContext.Formularios.FirstOrDefaultAsync(x => x.Id == id);
            if (formularioModels == null)
            {
                return NotFound();
            }

            formularioModels = mapper.Map(editarFormularioDto, formularioModels);
            await dbContext.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Eliminar([FromRoute] int id)
        {
            var existe = await dbContext.Formularios.AnyAsync(x => x.Id == id);
            if (!existe)
            {
                return NotFound();
            }

            dbContext.Formularios.Remove(new Formulario() { Id = id });
            await dbContext.SaveChangesAsync();
            return NoContent();
        }

        [HttpGet("listarsp")]
        public async Task<ActionResult<List<FormularioDto>>> ListarSP()
        {
            using(var connection = dapperDbContext.CreateConnection())
            {
                var formularios = await connection.QueryAsync<Formulario>("SP_Listar_Formularios");
                var formulariosDto = mapper.Map<List<FormularioDto>>(formularios);
                return formulariosDto;
            }
        }
    }
}
