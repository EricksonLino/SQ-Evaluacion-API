using System.ComponentModel.DataAnnotations;

namespace SQ_Evaluacion_API.Dtos
{
    public class FormularioDto
    {
        public int Id { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public string RazonSocial { get; set; }
        public string Ruc { get; set; }
        public string Mensaje { get; set; }
    }
}
