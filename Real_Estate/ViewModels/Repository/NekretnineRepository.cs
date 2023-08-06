using Real_Estate.Models;
using Real_Estate.ViewModels.Data;

namespace Real_Estate.ViewModels.Repository
{
    public class NekretnineRepository
    {
        private readonly AppDbContext context;

        public NekretnineRepository(AppDbContext _context)
        {
            context = _context;
        }

        public List<Nekretnine> FindNekretnineByProdavac(int id)
        {
            return context.Nekretnine.Where(n => n.IdKorisnika == id).ToList();
        }

        public List<Nekretnine> FindNekretnineByIdOpstine(int idOpstine, string tipStanja, string tipNekretnine)
        {

            return context.Nekretnine.Where(n => n.IdOpstine == idOpstine).ToList();
        }

    }
}
