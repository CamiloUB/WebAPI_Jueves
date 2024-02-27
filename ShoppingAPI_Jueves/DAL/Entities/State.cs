using System.ComponentModel.DataAnnotations;

namespace ShoppingAPI_Jueves.DAL.Entities
{
    public class State : AuditBase
    {
        [Display(Name = "Estado/Provincia")]
        [MaxLength(50, ErrorMessage = "El campo{0} debe tener máximo {1} caracteres. ")]
        [Required]
        public string Name { get; set; }
        
        
        [Display(Name = "País")]
        public Country? Country { get; set; } // Esta es la relación entre entidades


        [Display(Name = "Id País")]
        public Guid CountryId { get; set; } // Esta es la clave foranea(FK)

    }
}
