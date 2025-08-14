using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Sgmj.Modelos.Models;
using SGMJ.Dados.Models;
using System;
using System.IO;

namespace SGMJ.Dados.Banco.Context
{
    public class SgmjContext : IdentityDbContext<PessoaComAcesso, PerfilDeAcesso, int>
    {
        public DbSet<Jovem> Jovens { get; set; }
        public DbSet<Setor> Setores { get; set; }
        public DbSet<Congregacao> Congregacoes { get; set; }

        public SgmjContext(DbContextOptions<SgmjContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Congregacao>()
                .HasOne(c => c.Setor)
                .WithMany(s => s.Congregacoes)
                .HasForeignKey(c => c.SetorId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Jovem>()
                .HasOne(j => j.Congregacao)
                .WithMany(c => c.Jovens)
                .HasForeignKey(j => j.CongregacaoId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }

    public class SgmjContextFactory : IDesignTimeDbContextFactory<SgmjContext>
    {
        public SgmjContext CreateDbContext(string[] args)
        {
          var configuration = new ConfigurationBuilder()
              .SetBasePath(Directory.GetCurrentDirectory())
              .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
              .Build();

            var connectionString = configuration.GetConnectionString("ScreenSoundV0"); // ou nome da sua connection string

            if (string.IsNullOrEmpty(connectionString))
            {
                throw new InvalidOperationException("Connection string 'ScreenSoundV0' não encontrada no appsettings.json");
            }

            var optionsBuilder = new DbContextOptionsBuilder<SgmjContext>();
            
            optionsBuilder.UseSqlServer(connectionString, b => b.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery));
            

            return new SgmjContext(optionsBuilder.Options);
        }
    }  
}
