using GSMApp.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;

namespace GSMApp
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Producto> productos { get; set; }
        public DbSet<TiposProductos> Tiposproductos { get; set; }

    }
}
