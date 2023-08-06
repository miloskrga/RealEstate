using Real_Estate.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Real_Estate.Models
{
    public class Nekretnine
    {
        [Key]
        public int IdNekretnine { get; set; }
        public string Naziv { get; set; }
        public float Kvadratura { get; set; }
        public float BrojSoba { get; set; }
        public int Spratnost { get; set; }
        public int UkupnaSpratnost { get; set; }
        public float Cena { get; set; }
        public string Opis { get; set; }
        public string Saobracaj { get; set; }
        public string Prodato { get; set; }
        [ForeignKey("Korisnik")]
        public int IdKorisnika { get; set; }
        public Korisnik Korisnik { get; set; }
        public TipGrejanja IdTipGrejanja { get; set; }
        public TipStanja IdTipStanja { get; set; }
        public TipNekretnine IdTipNekretnine { get; set; }
        [ForeignKey("Ulica")]
        public int IdUlice { get; set; }
        public Ulica Ulica { get; set; }
        [ForeignKey("Mikrolokacija")]
        public int IdMikrolokacije { get; set; }
        public Mikrolokacija Mikrolokacija { get; set; }
        [ForeignKey("Opstina")]
        public int IdOpstine { get; set; }
        public Opstina Opstina { get; set; }
        [ForeignKey("Grad")]
        public int IdGrada { get; set; }
        public Grad Grad { get; set; }

        public List<Slike> slike { get; set; }
    }
}
