using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace FreimyHidalgo_AP1_P2.Models
{
    public class Articulos
    {

        [Key]
        public int ArticuloId { get; set; }

    
        [Required(ErrorMessage ="Campo descripcion obligatorio")]
        public string? Descripcion { get; set; }

        [Required(ErrorMessage ="Campo precio obligatorio")]
        public decimal? Precio { get; set; }

        
       public string? disponibilidad { get; set; }



    }
}
