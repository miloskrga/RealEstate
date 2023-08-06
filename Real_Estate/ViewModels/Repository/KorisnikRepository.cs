using Real_Estate.Models;
using Real_Estate.ViewModels.Data;
using Real_Estate.Models.Enums;

namespace Real_Estate.ViewModels.Repository
{
    public class KorisnikRepository
    {
        private readonly AppDbContext context;

        public KorisnikRepository(AppDbContext _context)
        {
            context = _context;
        }

        public void AddUser(Korisnik korisnik)
        {
            context.Korisnik.Add(korisnik);
            context.SaveChanges();
        }

        public void UpdateUser(Korisnik korisnik)
        {
            context.Korisnik.Update(korisnik);
            context.SaveChanges();
        }

        public Korisnik FindByUserName(string username)
        {
            return context.Korisnik.FirstOrDefault(k => k.Username== username);
        }

        public Korisnik FindByEmail(string email)
        {
            return context.Korisnik.FirstOrDefault(k => k.Email == email); 
        }

        public Korisnik FindById(int id)
        {
            return context.Korisnik.FirstOrDefault(k => k.IdKorisnika == id);
        }

        public List<Korisnik> FindByIdTipKorisnikaIdGrada(int? idGrada, string tipKorisnika)
        {
            Grad _grad = context.Grad.FirstOrDefault(g => g.IdGrada == idGrada);

            if (tipKorisnika == "Owner")
            {
                return context.Korisnik.Where(k => k.IdTipKorisnika == TipKorisnika.Owner && k.NazivGrada == _grad.NazivGrada).ToList();
            }
            if (tipKorisnika == "Customer")
            {
                return context.Korisnik.Where(k => k.IdTipKorisnika == TipKorisnika.Customer && k.NazivGrada == _grad.NazivGrada).ToList();
            }
            return null;
        }

    }
}
