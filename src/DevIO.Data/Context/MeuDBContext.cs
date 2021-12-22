using DevIO.Business.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DevIO.Data.Context
{
    public class MeuDBContext : DbContext
    {
        public MeuDBContext(DbContextOptions options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            ChangeTracker.AutoDetectChangesEnabled = false;
        }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Tamanho default para o campo que não foi setado
            // foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetProperties().Where(p => p.ClrType == typeof(string))))
            //    property.Relational().ColumnType = "varchar(100)";

            //Registrar Mappings
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MeuDBContext).Assembly);

            //Não deleter filhos no banco de dados
            foreach(var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
                relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;





                base.OnModelCreating(modelBuilder);
        }
    }
}
