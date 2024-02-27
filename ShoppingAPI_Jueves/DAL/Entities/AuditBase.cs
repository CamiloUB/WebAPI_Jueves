using System.ComponentModel.DataAnnotations;

namespace ShoppingAPI_Jueves.DAL.Entities
{
    public class AuditBase
    {

        [Key] // Pk
        [Required] // Pk
        public virtual Guid Id { get; set; } // PK de todas las tablas

        public virtual DateTime? CreatedDate { get; set; }

        public virtual DateTime? ModifiedDate { get; set; } 


    }
}
