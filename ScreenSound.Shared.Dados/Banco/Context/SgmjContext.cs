using Microsoft.EntityFrameworkCore;
using Sgmj.Modelos.Models;

namespace SGMJ.Dados.Banco.Context
{
    public class SgmjContext : DbContext
    {
        public DbSet<Jovem> Jovens { get; set; }
        public DbSet<Setor> Setores { get; set; }

        public SgmjContext()
        {

        }
        public SgmjContext(DbContextOptions options) : base(options)
        {

        }
        private string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ScreenSoundV0;Integrated Security=True;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured)
            {
                return;
            }
            optionsBuilder
                 .UseSqlServer(connectionString)
                 .UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Jovem>()
            .HasOne(j => j.Setor)    // Um Jovem tem apenas um Setor
            .WithMany(s => s.Jovens) // Um Setor tem muitos Jovens
            .HasForeignKey(j => j.SetorId); // A chave estrangeira está na entidade Jovem
        }
    }
}
