using System.ComponentModel.DataAnnotations;

namespace Modelos
{
    public class Usuario
    {
        [Required(ErrorMessage = "El Campo Código es Obligatorio")]
        public string Codigo { get; set; }
        [Required(ErrorMessage = "El Campo Nombre es Obligatorio")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El Campo Rol es Obligatorio")]
        public string Rol { get; set; }
        public string Clave { get; set; }
        public bool EstaActivo { get; set; }
    }
}