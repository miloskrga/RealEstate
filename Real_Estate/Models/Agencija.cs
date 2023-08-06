using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Real_Estate.Models
{
    public class Agencija
    {
        [Key]
        public int IdAgencije { get; set; }
        [Required]
        public string Naziv { get; set; }
        [Required]
        public string Adresa { get; set; }
        [Required]
        public string PIB { get; set; }
        [Required]
        public string Telefon { get; set; }
        [Required]
        public int IdGrada { get; set; }
        public  Grad Grad { get; set; }

    }
}
