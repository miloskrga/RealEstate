using Real_Estate.Models;
using Real_Estate.Models.Enums;

namespace Real_Estate.ViewModels
{
    public class AgencijaViewModel
    {
        public static string ProveraAgencije(Agencija agencija)
        {

            if (agencija.Naziv == null || agencija.Adresa == null || agencija.PIB == null || agencija.Telefon == null || agencija.IdGrada == null)
            {
                return "Molimo Vas da popunite sva polja";
            }

            foreach (var tel in agencija.Telefon)
            {
                if (!char.IsDigit(tel))
                {
                    return "Telefon sadrzi slovo ili neki drugi nedozvoljeni karakter";
                }
            }

            if (agencija.PIB.Length < 9 || agencija.PIB.Length > 9) 
            {
                return "PIB mora sadrzati tacno 9 brojeva";
            }

            foreach (var pib in agencija.PIB)
            {
                if (!char.IsDigit(pib))
                {
                    return "PIB sadrzi slovo ili neki drugi nedozvoljeni karakter";
                }
            }
            return "Ok";
        }
    }
}
