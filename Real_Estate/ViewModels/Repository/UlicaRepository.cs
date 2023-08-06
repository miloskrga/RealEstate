using Real_Estate.Models;
using Real_Estate.ViewModels.Data;

namespace Real_Estate.ViewModels.Repository
{
    public class UlicaRepository
    {
        private readonly AppDbContext context;
        public UlicaRepository(AppDbContext _context)
        {
            context = _context;
        }

        public List<Ulica> GetAllUlica(int mikrolokacijaid)
        {
            return context.Ulica.Where(u => u.IdMikrolokacije == mikrolokacijaid).ToList();
        }

        public void AddUlica(Ulica ulica)
        {       
            try
            {
                context.Ulica.Add(ulica);
                context.SaveChanges();
            }
            catch (Exception)
            {

            }
           
        }
        public void DeleteUlica(int idUlice)
        {
            var ulica = context.Ulica.FirstOrDefault(u => u.IdUlice == idUlice);

            try
            {
                context.Ulica.Remove(ulica);
                context.SaveChanges();
            }
            catch (Exception)
            {
                //ModelState.AddModelError("", "Unable to Delete Ucesce");
            }
        }
    }
}
