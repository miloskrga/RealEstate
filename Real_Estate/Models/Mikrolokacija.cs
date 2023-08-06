using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Real_Estate.Models
{
    public class Mikrolokacija
    {
        [Key]
        public int IdMikrolokacije { get; set; }
        public string NazivMikrolokacije { get; set; }
        [ForeignKey("Opstina")]
        public int? IdOpstine { get; set; }
        public Opstina Opstina { get; set; }
    }
}
