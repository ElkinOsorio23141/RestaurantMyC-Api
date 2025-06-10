using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using RestaurantMyC_Api.Models;

namespace RestaurantMyC_Api;

public partial class RestauratMyCContext : DbContext
{
    public RestauratMyCContext()
    {
    }

    public RestauratMyCContext(DbContextOptions<RestauratMyCContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CategoriasPlatos> CategoriasPlatos { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Mesa> Mesas { get; set; }

    public virtual DbSet<Pedido> Pedidos { get; set; }

    public virtual DbSet<Plato> Platos { get; set; }

    public virtual DbSet<Reserva> Reservas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=ASUS-PC\\SQLEXPRESS; DataBase=RestauratMyC; Integrated Security=true; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CategoriasPlatos>(entity =>
        {
            entity.HasKey(e => e.IdCategoria);

            entity.ToTable("Categorias_Platos");

            entity.Property(e => e.IdCategoria)
                .ValueGeneratedOnAdd()
                .HasColumnType("numeric(18, 0)");
            entity.Property(e => e.NombreCategoria)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.IdCliente).HasName("PK_Clientes_1");

            entity.Property(e => e.IdCliente)
                .ValueGeneratedOnAdd()
                .HasColumnType("numeric(18, 0)");
            entity.Property(e => e.ApellidosCliente)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Correo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.IdentificacionCliente)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.NombreCliente)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Mesa>(entity =>
        {
            entity.HasKey(e => e.IdMesa);

            entity.Property(e => e.IdMesa)
                .ValueGeneratedOnAdd()
                .HasColumnType("numeric(18, 0)");
            entity.Property(e => e.Capacidad).HasColumnType("numeric(18, 0)");
            entity.Property(e => e.Ubicacion)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Pedido>(entity =>
        {
            entity.HasKey(e => e.IdPedido).HasName("PK_Pedidos_1");

            entity.Property(e => e.IdPedido)
                .ValueGeneratedOnAdd()
                .HasColumnType("numeric(18, 0)");
            entity.Property(e => e.Cantidad).HasColumnType("numeric(18, 0)");
            entity.Property(e => e.FechaPedido).HasColumnType("smalldatetime");
            entity.Property(e => e.IdCliente).HasColumnType("numeric(18, 0)");
            entity.Property(e => e.IdPlato).HasColumnType("numeric(18, 0)");
            entity.Property(e => e.NumeroPedido)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.ValorTotal).HasColumnType("money");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Pedidos)
                .HasForeignKey(d => d.IdCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Pedidos_Clientes");

            entity.HasOne(d => d.IdPlatoNavigation).WithMany(p => p.Pedidos)
                .HasForeignKey(d => d.IdPlato)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Pedidos_Platos");
        });

        modelBuilder.Entity<Plato>(entity =>
        {
            entity.HasKey(e => e.IdPlato);

            entity.Property(e => e.IdPlato)
                .ValueGeneratedOnAdd()
                .HasColumnType("numeric(18, 0)");
            entity.Property(e => e.IdCategoria).HasColumnType("numeric(18, 0)");
            entity.Property(e => e.NombrePlato)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Precio).HasColumnType("money");

            entity.HasOne(d => d.IdCategoriaNavigation).WithMany(p => p.Platos)
                .HasForeignKey(d => d.IdCategoria)
                .HasConstraintName("FK_Categorias_Platos");
        });

        modelBuilder.Entity<Reserva>(entity =>
        {
            entity.HasKey(e => e.IdReserva);

            entity.Property(e => e.IdReserva)
                .ValueGeneratedOnAdd()
                .HasColumnType("numeric(18, 0)");
            entity.Property(e => e.FechaReserva).HasColumnType("date");
            entity.Property(e => e.IdCliente).HasColumnType("numeric(18, 0)");
            entity.Property(e => e.IdMesa).HasColumnType("numeric(18, 0)");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Reservas)
                .HasForeignKey(d => d.IdCliente)
                .HasConstraintName("FK_Reservas_Clientes");

            entity.HasOne(d => d.IdMesaNavigation).WithMany(p => p.Reservas)
                .HasForeignKey(d => d.IdMesa)
                .HasConstraintName("FK_Reservas_Mesas");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
