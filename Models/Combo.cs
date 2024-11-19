using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FreimyHidalgo_AP1_P2.Models
{
    public class Combo
    {
        [Key]
        public int ComboId { get; set; }

        [Required(ErrorMessage="Campo fecha obligatorio")]

        public DateTime Fecha {  get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Campo descripcion obligatorio")]
        public string? descripcion { get; set; }

        [Required(ErrorMessage = "Campo precio obligatorio")]
        public decimal precio { get; set; }

        public bool Vendido { get; set; }

        [ForeignKey("ComboId")]

        public ICollection<ComboDetalle> ComboDetalle { get; set; } = new List<ComboDetalle>();


    }
}
