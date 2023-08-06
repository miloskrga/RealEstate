using Real_Estate.Models;
using Real_Estate.Models.Enums;

namespace Real_Estate.ViewModels
{
    public class KorisnikViewModel
    {
        public static string ProveraKorisnika(Korisnik korisnik)
        {
            
            if(korisnik.Ime == null || 
                korisnik.Prezime==null ||
                korisnik.Email==null ||
                korisnik.Password==null ||
                korisnik.Username==null ||
                korisnik.Telefon==null ||
                korisnik.IdTipKorisnika==TipKorisnika.None ||
                korisnik.DatumRodjenja== new DateTime() ||
                korisnik.NazivGrada==null ||
                (korisnik.IdTipKorisnika==TipKorisnika.Owner && korisnik.IdAgencije==null))
            {
                return "Molimo Vas da popunite sva polja";
            }

            if (!korisnik.Email.Contains("@") || !korisnik.Email.Contains("."))
            {
                return "Email nije validan";
            }

            if (korisnik.Password.Length < 5)
            {
                return "Password mora biti bar 5 karaktera";
            }

            if(korisnik.DatumRodjenja > DateTime.Now)
            {
                return "Datum Rodjenja nije validan";
            }

            foreach(var tel in korisnik.Telefon)
            {
                if (!char.IsDigit(tel)) 
                {
                    return "Telefon sadrzi slovo ili neki drugi nedozvoljeni karakter";
                }
            }

            //validacija username i grada

            return "Ok";
        }
    }
}
