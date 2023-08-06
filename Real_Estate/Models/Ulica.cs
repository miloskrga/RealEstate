using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Real_Estate.Models
{
    public class Ulica
    {
        [Key]
        public int IdUlice { get; set; }
        public string NazivUlice { get; set; }
        [ForeignKey("Mikrolokacija")]
        public int IdMikrolokacije { get; set; }
        public Mikrolokacija Mikrolokacija { get; set; }
    }
}
