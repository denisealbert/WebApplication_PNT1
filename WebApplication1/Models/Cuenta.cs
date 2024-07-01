using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApplication_PNT1.Models
{
    public class Cuenta
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdCuenta { get; set; }

        [Display(Name = "DNI")]
        public required string Dni { get; set; }


        [Display(Name = "Clave")] public required string Clave { get; set; }

    }
}
