namespace examen2.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ReservaRestaurante : DbContext
    {
        public ReservaRestaurante()
            : base("name=ReservaRestaurante")
        {
        }

        public virtual DbSet<Categoria> Categoria { get; set; }
        public virtual DbSet<Reserva> Reserva { get; set; }
        public virtual DbSet<Restaurante> Restaurante { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoria>()
                .Property(e => e.descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Categoria>()
                .HasMany(e => e.Restaurante)
                .WithRequired(e => e.Categoria)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Reserva>()
                .Property(e => e.total)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Restaurante>()
                .Property(e => e.descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Restaurante>()
                .Property(e => e.direccion)
                .IsUnicode(false);

            modelBuilder.Entity<Restaurante>()
                .Property(e => e.precioxComensal)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Restaurante>()
                .HasMany(e => e.Reserva)
                .WithRequired(e => e.Restaurante)
                .WillCascadeOnDelete(false);
        }
    }
}
