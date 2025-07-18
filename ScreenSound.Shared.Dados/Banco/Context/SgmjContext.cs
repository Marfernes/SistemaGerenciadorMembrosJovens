using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Sgmj.Modelos.Models;
using SGMJ.Dados.Models;

namespace SGMJ.Dados.Banco.Context
{
    public class SgmjContext : IdentityDbContext<PessoaComAcesso, PerfilDeAcesso, int>
    {
        public DbSet<Jovem> Jovens { get; set; }
        public DbSet<Setor> Setores { get; set; }

        public SgmjContext(DbContextOptions<SgmjContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Jovem>()
                .HasOne(j => j.Setor)
                .WithMany(s => s.Jovens)
                .HasForeignKey(j => j.SetorId);
        }
    }
}
