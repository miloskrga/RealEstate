using Real_Estate.Models;
using Real_Estate.ViewModels.Data;

namespace Real_Estate.ViewModels.Repository
{
    public class OpstinaRepository
    {
        private readonly AppDbContext context;
        public OpstinaRepository(AppDbContext _context)
        {
            context = _context;
        }

        public List<Opstina> GetAllOpstina(int idgrada)
        {

            return context.Opstina.Where(o => o.IdGrada==idgrada).ToList();
        }
    }
}
