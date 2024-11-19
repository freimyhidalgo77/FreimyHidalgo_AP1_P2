using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FreimyHidalgo_AP1_P2.Models
{
    public class ComboDetalle
    {
        [Key]
        public int DetalleId { get; set; }

        [ForeignKey("Combo")]
        public int ComboId { get; set; }
        Combo? Combos { get; set; }


        [ForeignKey("Articulos")]
        public int ArticuloId { get; set; }
        Articulos? Articulos { get; set; }


        [Required(ErrorMessage = "Es obligatorio introducir una cantidad ")]
        public int cantidad { get; set; }

        [Required(ErrorMessage = "Es obligatorio introducir un precio")]
        public decimal Costo { get; set; }





    }
}
