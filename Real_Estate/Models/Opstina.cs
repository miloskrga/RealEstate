using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Real_Estate.Models
{
    public class Opstina
    {
        [Key]
        public int IdOpstine { get; set; }
        public string NazivOpstine { get; set; }
        [ForeignKey("Grad")]
        public int IdGrada { get; set; }
        public Grad Grad { get; set; }
    }
}
