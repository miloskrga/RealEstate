using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Real_Estate.Models
{
    public class Slike
    {
        [Key]
        public int IdSlike { get; set; }
        public string Naziv { get; set; }
        [ForeignKey("Nekretnine")]
        public int IdNekretnine { get; set; }
        public Nekretnine Nekretnine { get; set; }
    }
}
