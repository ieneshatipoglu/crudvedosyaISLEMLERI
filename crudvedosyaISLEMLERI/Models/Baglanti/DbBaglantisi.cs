using Microsoft.EntityFrameworkCore;
using crudvedosyaISLEMLERI.Models;

namespace crudvedosyaISLEMLERI.Models.Baglanti
{
    public class DbBaglantisi : DbContext
    {
        public DbBaglantisi(DbContextOptions<DbBaglantisi>options)
            : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }
        public DbSet<Sarki>Sarkilar {  get; set; }
    }
}
