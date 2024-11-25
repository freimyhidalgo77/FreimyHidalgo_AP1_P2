using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FreimyHidalgo_AP1_P2.Models
{
    public class CombosDetalle
    {
        [Key]
        public int DetalleId { get; set; }

        [ForeignKey("Combo")]
        public int ComboId { get; set; }
        public Combo1? Combos { get; set; }


        [ForeignKey("Articulos")]
        public int ArticuloId { get; set; }
        public  Producto? Articulos { get; set; }


        [Required(ErrorMessage = "Es obligatorio introducir una cantidad ")]
        public int Cantidad { get; set; }

        [Required(ErrorMessage = "Es obligatorio introducir un precio")]
        public decimal costo { get; set; }





    }
}
