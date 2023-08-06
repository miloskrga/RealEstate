using Microsoft.EntityFrameworkCore;
using Real_Estate.Models;
using Real_Estate.ViewModels.Data;

namespace Real_Estate.ViewModels.Repository
{
    public class AgencijaRepository
    {
        private readonly AppDbContext context;
        public AgencijaRepository(AppDbContext _context)
        {
            context = _context;
        }
        public List<Agencija> GetAllAgencija(int idGrada)
        {
            return context.Agencija.Where(a => a.IdGrada == idGrada).ToList();
        }

        public Agencija FindById(int? idagencija)
        {
            return context.Agencija.FirstOrDefault(a => a.IdAgencije==idagencija);

        }
        public void AddAgenciju(Agencija agencija)
        {
            try
            {
                context.Agencija.Add(agencija);
                context.SaveChanges();
            }
            catch (Exception)
            {

            }
        }
        public void UpdateAgencija(Agencija agencija)
        {          
            try
            {
                context.Agencija.Update(agencija);
                context.SaveChanges();
            }
            catch (Exception)
            {

            }
        }
        public void DeleteAgenciju(int IdAgencije)
        {
            var agencija = context.Agencija.FirstOrDefault(a => a.IdAgencije == IdAgencije);

            try
            {
                context.Agencija.Remove(agencija);
                context.SaveChanges();
            }
            catch (Exception)
            {
                //ModelState.AddModelError("", "Unable to Delete Ucesce");
            }
        }
    }
}
