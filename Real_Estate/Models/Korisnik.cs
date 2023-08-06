using Real_Estate.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Real_Estate.Models
{
    public class Korisnik
    {
        [Key]
        public int IdKorisnika { get; set; }
        [Required]
        public string Ime { get; set; }
        [Required]
        public string Prezime { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Telefon { get; set; }
        [Required]
        public DateTime DatumRodjenja { get; set; }
        [Required]
        public TipKorisnika IdTipKorisnika { get; set; }
        [ForeignKey("Agencija")]
        public int? IdAgencije { get; set; }
        public Agencija Agencija { get; set; }
        [Required]
        public string NazivGrada { get; set; }

    }

    
}
