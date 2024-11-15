using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace FreimyHidalgo_AP1_P2.Models
{
    public class Registro
    {
        [Key]

        public int RegistroId { get; set; }

        [Required(ErrorMessage = "Por favor ingrese un nombre")]
        public string? Nombre { get; set; }


    }
}
