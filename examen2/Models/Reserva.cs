namespace examen2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Reserva")]
    public partial class Reserva
    {
        [Key]
        public int idReserva { get; set; }

        [Column(TypeName = "date")]
        public DateTime fecha { get; set; }

        [Required]
        [StringLength(12)]
        public string hora { get; set; }

        [Required]
        [StringLength(150)]
        public string nombre { get; set; }

        [Required]
        [StringLength(50)]
        public string telefono { get; set; }

        [Required]
        [StringLength(20)]
        public string email { get; set; }

        public int idRestaurante { get; set; }

        public int numeroPersonas { get; set; }

        public decimal total { get; set; }

        public virtual Restaurante Restaurante { get; set; }
    }
}
