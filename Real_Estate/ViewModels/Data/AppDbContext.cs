using Microsoft.EntityFrameworkCore;
using Real_Estate.Models;

namespace Real_Estate.ViewModels.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Grad>()
                .HasMany(g => g.Agencije)
                .WithOne(a => a.Grad)
                .HasForeignKey(a => a.IdGrada);
        }

       
        public DbSet<Agencija> Agencija { get; set; }
        public DbSet<Grad> Grad { get; set; }
        public DbSet<Opstina> Opstina { get; set; }
        public DbSet<Mikrolokacija> Mikrolokacija { get; set; }
        public DbSet<Ulica> Ulica { get; set; }
        public DbSet<Korisnik> Korisnik { get; set; }
        public DbSet<Nekretnine> Nekretnine { get; set; }
        
    }
}
