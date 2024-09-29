using Academia;
using Microsoft.EntityFrameworkCore;
using Academia.Repositorys;

namespace Academia.Models
{
    public class AcademiaContext : DbContext
    {
        public DbSet<MAlunos> Alunos { get; set; } = null!;
        public DbSet<MPlanos> Planos { get; set; } = null!;
        public DbSet<MAulas> Aulas { get; set; } = null!;
        public DbSet<MContratos> Contratos { get; set; } = null!;
        public DbSet<MDespesas> Despesas { get; set; } = null!;
        public DbSet<MEnderecos> Enderecos { get; set; } = null!;
        public DbSet<MFuncionarios> Funcionarios { get; set; } = null!;
        public DbSet<MInventario> Inventario { get; set; } = null!;
        public DbSet<MReceitas> Receitas { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();

                optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            }
        }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<MEnderecos>()
                .HasOne<MAlunos>()
                .WithMany()
                .HasForeignKey(r => r.Id_aluno)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<MEnderecos>()
                .HasOne<MFuncionarios>()
                .WithMany()
                .HasForeignKey(r => r.Id_funcionario)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<MAlunos>()
                .HasOne<MEnderecos>()
                .WithMany()
                .HasForeignKey(r => r.Id_endereco)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<MAlunos>()
                .HasOne<MAulas>()
                .WithMany()
                .HasForeignKey(r => r.Id_aula)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<MAlunos>()
                .HasOne<MContratos>()
                .WithMany()
                .HasForeignKey(r => r.Id_contrato)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<MAulas>()
                .HasOne<MFuncionarios>()
                .WithMany()
                .HasForeignKey(r => r.Id_funcionario)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<MAulas>()
                .HasOne<MAlunos>()
                .WithMany()
                .HasForeignKey(r => r.Id_aluno)
                .OnDelete(DeleteBehavior.Restrict);
            
            modelBuilder.Entity<MContratos>()
                .HasOne<MAlunos>()
                .WithMany()
                .HasForeignKey(r => r.Id_aluno)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<MContratos>()
                .HasOne<MPlanos>()
                .WithMany()
                .HasForeignKey(r => r.Id_plano)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<MContratos>()
                .HasOne<MReceitas>()
                .WithMany()
                .HasForeignKey(r => r.Id_receita)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<MContratos>()
                .HasOne<MFuncionarios>()
                .WithMany()
                .HasForeignKey(r => r.Id_funcionario)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<MDespesas>()
                .HasOne<MFuncionarios>()
                .WithMany()
                .HasForeignKey(r => r.Id_funcionario)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<MFuncionarios>()
                .HasOne<MEnderecos>()
                .WithMany()
                .HasForeignKey(r => r.Id_endereco)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<MFuncionarios>()
                .HasOne<MDespesas>()
                .WithMany()
                .HasForeignKey(r => r.Id_despesas)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<MFuncionarios>()
                .HasOne<MAulas>()
                .WithMany()
                .HasForeignKey(r => r.Id_aula)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<MReceitas>()
                .HasOne<MAlunos>()
                .WithMany()
                .HasForeignKey(r => r.Id_aluno)
                .OnDelete(DeleteBehavior.Restrict);



            base.OnModelCreating(modelBuilder);
        }
    }
}
