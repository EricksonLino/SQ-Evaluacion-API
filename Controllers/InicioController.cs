using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SQ_Evaluacion_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InicioController : ControllerBase
    {
        [HttpGet, Route("")]
        public string Obtener()
        {
            return "Inicio";
        }
    }
}
