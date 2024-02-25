using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ShoppingAPI_Jueves.DAL.Entities
{
    public class Country : AuditBase
    {
        [Display(Name = "País")]
         // [MaxLenght(50, ErrorMessage = "El campo{0} debe tener máximo {1} caracteres. ")]
        [Required]
        public string Name { get; set; }
    }
}
