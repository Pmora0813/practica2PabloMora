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
        [Display(Name = "Fecha")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}",
            ApplyFormatInEditMode = true)]
        public DateTime fecha { get; set; }

        [Required]
        [StringLength(12)]
        [Display(Name = "Hora")]
        public string hora { get; set; }

        [Required]
        [StringLength(150)]
        [Display(Name = "Nombre")]
        public string nombre { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Telefóno")]
        public string telefono { get; set; }

        [Required]
        [StringLength(20)]
        [Display(Name = "Email")]
        public string email { get; set; }

        [Display(Name = "Restaurante")]
        public int idRestaurante { get; set; }

        [Display(Name = "Numero de Personas")]
        public int numeroPersonas { get; set; }

        [Display(Name = "Total")]
        public decimal total { get; set; }

        public virtual Restaurante Restaurante { get; set; }
    }
}
