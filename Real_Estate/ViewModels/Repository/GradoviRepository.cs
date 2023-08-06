using Microsoft.EntityFrameworkCore;
using Real_Estate.Models;
using Real_Estate.ViewModels.Data;

namespace Real_Estate.ViewModels.Repository
{
    public class GradoviRepository
    {
        private readonly AppDbContext context;
        public GradoviRepository(AppDbContext _context)
        {
            context = _context;
        }

        public List<Grad> GetAllGradovi(){

            return context.Grad.ToList();
        }


    }
}
