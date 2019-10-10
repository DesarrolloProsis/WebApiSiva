using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using WebApiSiva.Entities;

namespace WebApiSiva.Entities
{
    public partial class GTDbContext : DbContext
    {
        public GTDbContext()
        {
        }

        public GTDbContext(DbContextOptions<GTDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Carriles> Carriles { get; set; }
        public virtual DbSet<Clientes> Clientes { get; set; }
        public virtual DbSet<CuentasTelepeajes> CuentasTelepeajes { get; set; }
        public virtual DbSet<Historico> Historico { get; set; }
        public virtual DbSet<ListaNegra> ListaNegra { get; set; }
        public virtual DbSet<Location> Location { get; set; }
        public virtual DbSet<OperacionesSerBipagos> OperacionesSerBipagos { get; set; }
        public virtual DbSet<Operadores> Operadores { get; set; }
        public virtual DbSet<Tags> Tags { get; set; }
        public virtual DbSet<TipoVehiculo> TipoVehiculo { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Carriles>(entity =>
            {
                entity.HasKey(e => e.Carril)
                    .HasName("PK_dbo.Carriles");

                entity.Property(e => e.Carril).HasMaxLength(3);

                entity.Property(e => e.FechaAlta).HasColumnType("datetime");
            });

            modelBuilder.Entity<Clientes>(entity =>
            {
                entity.Property(e => e.AddressCliente).HasMaxLength(300);

                entity.Property(e => e.Apellidos)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.Cp).HasColumnName("CP");

                entity.Property(e => e.DateTcliente)
                    .HasColumnName("DateTCliente")
                    .HasColumnType("datetime");

                entity.Property(e => e.EmailCliente).HasMaxLength(150);

                entity.Property(e => e.IdCajero)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.Nit).HasColumnName("NIT");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.NumCliente)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.PhoneCliente).HasMaxLength(50);
            });

            modelBuilder.Entity<CuentasTelepeajes>(entity =>
            {
                entity.HasIndex(e => e.ClienteId)
                    .HasName("IX_ClienteId");

                entity.Property(e => e.DateTcuenta)
                    .HasColumnName("DateTCuenta")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdCajero)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.NumCuenta)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.SaldoCuenta).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.TypeCuenta)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.HasOne(d => d.Cliente)
                    .WithMany(p => p.CuentasTelepeajes)
                    .HasForeignKey(d => d.ClienteId)
                    .HasConstraintName("FK_dbo.CuentasTelepeajes_dbo.Clientes_ClienteId");
            });

            modelBuilder.Entity<Historico>(entity =>
            {
                entity.HasKey(e => new { e.Tag, e.Fecha, e.Carril })
                    .HasName("PK_dbo.Historico");

                entity.HasIndex(e => e.Carril)
                    .HasName("IX_Carril");

                entity.HasIndex(e => e.IdClase)
                    .HasName("IX_IdClase");

                entity.HasIndex(e => e.IdLocation)
                    .HasName("IX_IdLocation");

                entity.HasIndex(e => e.IdOperador)
                    .HasName("IX_IdOperador");

                entity.Property(e => e.Tag).HasMaxLength(20);

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.Property(e => e.Carril).HasMaxLength(3);

                entity.Property(e => e.Cargo).HasColumnType("decimal(6, 2)");

                entity.Property(e => e.NumeroCuenta).HasMaxLength(10);

                entity.Property(e => e.SaldoActualizado).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.SaldoAnterior).HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.CarrilNavigation)
                    .WithMany(p => p.Historico)
                    .HasForeignKey(d => d.Carril)
                    .HasConstraintName("FK_dbo.Historico_dbo.Carriles_Carril");

                entity.HasOne(d => d.IdClaseNavigation)
                    .WithMany(p => p.Historico)
                    .HasForeignKey(d => d.IdClase)
                    .HasConstraintName("FK_dbo.Historico_dbo.TipoVehiculo_IdClase");

                entity.HasOne(d => d.IdLocationNavigation)
                    .WithMany(p => p.Historico)
                    .HasForeignKey(d => d.IdLocation)
                    .HasConstraintName("FK_dbo.Historico_dbo.Location_IdLocation");

                entity.HasOne(d => d.IdOperadorNavigation)
                    .WithMany(p => p.Historico)
                    .HasForeignKey(d => d.IdOperador)
                    .HasConstraintName("FK_dbo.Historico_dbo.Operadores_IdOperador");
            });

            modelBuilder.Entity<ListaNegra>(entity =>
            {
                entity.Property(e => e.Clase).HasMaxLength(30);

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.IdCajero)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.NumCliente).HasMaxLength(30);

                entity.Property(e => e.NumCuenta).HasMaxLength(30);

                entity.Property(e => e.Numero)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Observacion)
                    .IsRequired()
                    .HasMaxLength(280);

                entity.Property(e => e.Tipo)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.HasKey(e => e.IdLocation)
                    .HasName("PK_dbo.Location");

                entity.Property(e => e.IdLocation).ValueGeneratedOnAdd();

                entity.Property(e => e.Delegacion).HasMaxLength(30);

                entity.Property(e => e.Plaza).HasMaxLength(10);
            });

            modelBuilder.Entity<OperacionesSerBipagos>(entity =>
            {
                entity.ToTable("OperacionesSerBIpagos");

                entity.Property(e => e.Concepto).HasMaxLength(30);

                entity.Property(e => e.DateTopSerBi)
                    .HasColumnName("DateTOpSerBI")
                    .HasColumnType("datetime");

                entity.Property(e => e.NoReferencia).HasMaxLength(30);

                entity.Property(e => e.NumAutoriBanco).HasMaxLength(20);

                entity.Property(e => e.NumAutoriProveedor).HasMaxLength(20);

                entity.Property(e => e.Numero).HasMaxLength(30);

                entity.Property(e => e.Tipo).HasMaxLength(20);
            });

            modelBuilder.Entity<Operadores>(entity =>
            {
                entity.HasKey(e => e.IdOperador)
                    .HasName("PK_dbo.Operadores");

                entity.Property(e => e.IdOperador).ValueGeneratedOnAdd();

                entity.Property(e => e.Operador).HasMaxLength(5);
            });

            modelBuilder.Entity<Tags>(entity =>
            {
                entity.HasIndex(e => e.CuentaId)
                    .HasName("IX_CuentaId");

                entity.Property(e => e.DateTtag)
                    .HasColumnName("DateTTag")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdCajero)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.NumTag)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.SaldoTag).HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.Cuenta)
                    .WithMany(p => p.Tags)
                    .HasForeignKey(d => d.CuentaId)
                    .HasConstraintName("FK_dbo.Tags_dbo.CuentasTelepeajes_CuentaId");
            });

            modelBuilder.Entity<TipoVehiculo>(entity =>
            {
                entity.HasKey(e => e.IdTipoVehiculo)
                    .HasName("PK_dbo.TipoVehiculo");

                entity.Property(e => e.IdTipoVehiculo).ValueGeneratedOnAdd();

                entity.Property(e => e.Tipo).HasMaxLength(6);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
