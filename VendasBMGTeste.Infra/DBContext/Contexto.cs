using Microsoft.EntityFrameworkCore;
using VendasBMGTeste.Domain.Models;

namespace VendasBMGTeste.Infra.DBContext
{
    public class Contexto : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseInMemoryDatabase(databaseName: "VendasDb");
        }

        public DbSet<Venda> Vendas { get; set; }

        public DbSet<Produto> Produtos { get; set; }
    }
}
