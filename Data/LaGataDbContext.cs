using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LaGata.Api.Entities;
using Microsoft.EntityFrameworkCore;
using LaGata.Api.DTOs;

namespace LaGata.Api.Data
{
    public class LaGataDbContext : DbContext
    {
        public LaGataDbContext(DbContextOptions<LaGataDbContext> options) : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Compra> Compras { get; set; }
        public DbSet<DetalleCompra> DetallesCompra { get; set; }
        public DbSet<Proveedor> Proveedores { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Marca> Marcas { get; set; }
        public DbSet<DetalleProducto> DetallesProducto { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Keyless DTOs for stored procedure mappings
            modelBuilder.Entity<LoginUsuarioDto>().HasNoKey();
            modelBuilder.Entity<UsuarioRolDto>().HasNoKey();
            modelBuilder.Entity<UsuarioAdminListadoDto>().HasNoKey();
            modelBuilder.Entity<UsuarioResumenDto>().HasNoKey();
            modelBuilder.Entity<CategoriaDto>().HasNoKey();
            modelBuilder.Entity<MarcaDto>().HasNoKey();
            modelBuilder.Entity<ProductoDto>().HasNoKey();
            modelBuilder.Entity<ClienteDto>().HasNoKey();
            modelBuilder.Entity<ProveedorDto>().HasNoKey();
            modelBuilder.Entity<DetalleProductoDto>().HasNoKey();
            
            // DTOs para Compras
            modelBuilder.Entity<CompraResponse>().HasNoKey();
            modelBuilder.Entity<DetalleCompraResponse>().HasNoKey();
            modelBuilder.Entity<CompraListResponse>().HasNoKey();
            modelBuilder.Entity<CompraResumenResponse>().HasNoKey();
            modelBuilder.Entity<TopProductoCompradoResponse>().HasNoKey();
        }
    }
}