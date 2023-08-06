using Real_Estate.Models;
using Real_Estate.ViewModels.Data;

namespace Real_Estate.ViewModels.Repository
{
    public class MikrolokacijaRepository
    {
        private readonly AppDbContext context;
        public MikrolokacijaRepository(AppDbContext _context)
        {
            context = _context;
        }

        public List<Mikrolokacija> GetAllMikrolokacija(int idopstine)
        {

            return context.Mikrolokacija.Where(m => m.IdOpstine == idopstine).ToList();
        }

        public void AddMikrolokacija(Mikrolokacija mikrolokacija)
        {
            context.Mikrolokacija.Add(mikrolokacija);
            context.SaveChanges();
        }
        public void DeleteMikrolokacija(int IdMikro)
        {
            var mikro = context.Mikrolokacija.FirstOrDefault(m => m.IdMikrolokacije == IdMikro);

            try
            {
                context.Mikrolokacija.Remove(mikro);
                context.SaveChanges();
            }
            catch (Exception)
            {
                //ModelState.AddModelError("", "Unable to Delete Ucesce");
            }
        }
    }
}
