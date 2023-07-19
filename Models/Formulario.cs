using System.ComponentModel.DataAnnotations;

namespace SQ_Evaluacion_API.Models
{
    public class Formulario
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Nombres { get; set; }
        [Required]
        [StringLength(100)]
        public string Apellidos { get; set; }
        [Required]
        [StringLength(100)]
        public string Correo { get; set; }
        [Required]
        [StringLength(100)]
        public string Telefono { get; set; }
        [Required]
        [StringLength(100)]
        public string RazonSocial { get; set; }
        [Required]
        [StringLength(10)]
        public string Ruc { get; set; }
        [Required]
        public string Mensaje { get; set; }
    }
}
