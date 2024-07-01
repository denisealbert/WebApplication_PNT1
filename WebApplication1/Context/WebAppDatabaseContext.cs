using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication_PNT1.Models;
using System.Collections.Generic;
using System.Reflection.Emit;


namespace WebApplication_PNT1.Context
{
    public class WebAppDatabaseContext : DbContext
    {
        public WebAppDatabaseContext(DbContextOptions<WebAppDatabaseContext> options) : base(options)
        {
        }
        public DbSet<Proyecto> Proyectos { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Pedido>()
                .HasKey(p => p.IdPedido);
            modelBuilder.Entity<Proyecto>()
                .HasKey(p => p.IdProyecto);

            // Configurar la relación entre Pedido y Proyecto
            modelBuilder.Entity<Proyecto>()
                .HasOne(p => p.Pedido)
                .WithMany(b => b.Proyectos)
                .HasForeignKey(p => p.PedidoId);
        }
        public DbSet<WebApplication_PNT1.Models.Cuenta> Cuenta { get; set; } = default!;
    }
}
