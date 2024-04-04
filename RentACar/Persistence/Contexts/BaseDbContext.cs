using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace Persistence.Contexts
{
    public class BaseDbContext : DbContext
    {
        protected IConfiguration Configuration { get; set; }
        public DbSet<Brand> Brands { get; set; }

        public BaseDbContext(DbContextOptions dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
        {
            Configuration = configuration; // veritabanına yol oluşturuluyor configuration ile 
            Database.EnsureCreated(); // önce veritabanının oluştuğundan emin ol diyoruz
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly()); // git mevcut assemblydeki configurasyonları bul onları direkt uygula dedik.
            // veritabanıyla ilgili hangi alan neye karşılık gibi configurasyonları yapmak için.
            // Bunu mutlaka yapın diyor hoca çünkü sektörde veritabanlarındaki isimler eskiden kaldığı için genellikle kötüdür diyor.
            // madem ORM kullanıyoruz onu da raconuna uygun kullanmak lazım.
        }
    }
}
