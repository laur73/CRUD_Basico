using System.ComponentModel.DataAnnotations;

namespace CRUDCore.Models
{
    public class ContactoViewModel
    {
        //Propiedades que hacen referencia a las columnas de la tabla
        public int IdContacto { get; set; }
        [Required(ErrorMessage ="El campo {0} es requerido")]
        [StringLength(maximumLength: 50)]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength: 10)]
        [Display(Name = "Teléfono")]
        public string Telefono { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength: 50)]
        [Display(Name = "Correo Electrónico")]
        public string Correo { get; set; }
    }
}

