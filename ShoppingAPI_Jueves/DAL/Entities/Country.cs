using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ShoppingAPI_Jueves.DAL.Entities
{
    public class Country : AuditBase
    {
        [Display(Name = "País")]
        [MaxLength(50, ErrorMessage = "El campo{0} debe tener máximo {1} caracteres. ")]
        [Required]
        public string Name { get; set; }

        [Display(Name = "Estados/Provincias")]
        public ICollection<State>? States { get; set; } // Esta es la relación entre entidades

    }
}
