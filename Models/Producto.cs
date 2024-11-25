using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace FreimyHidalgo_AP1_P2.Models
{
    public class Producto
    {

        [Key]
        public int ArticuloId { get; set; }

        public string? Descripcion { get; set; }

        public decimal Precio { get; set; }

        public decimal Costo { get; set; }

        public int existencia { get; set; }



    }
}
