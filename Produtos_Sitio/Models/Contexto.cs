using Microsoft.EntityFrameworkCore;
using Produtos_Sitio.Models;

namespace Produtos_Sitio.Models
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Venda> Vendas { get; set; }
        public DbSet<Entrega> Entregas { get; set; }
        public DbSet<Produtos_Sitio.Models.Usuario> Usuario { get; set; }

    }
}
