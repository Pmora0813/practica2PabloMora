namespace examen2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Restaurante")]
    public partial class Restaurante
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Restaurante()
        {
            Reserva = new HashSet<Reserva>();
        }

        [Key]
        public int idRestaurante { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Nombre")]
        public string nombre { get; set; }

        [Column(TypeName = "text")]
        [Required]
        [Display(Name = "Descripci�n")]
        [DataType(DataType.MultilineText)]
        public string descripcion { get; set; }

        [Column(TypeName = "text")]
        [Required]
        [Display(Name = "Direcci�n")]
        public string direccion { get; set; }

        [Display(Name = "Categor�a")]
        public int idCategoria { get; set; }

        [Display(Name = "Precio por Comensal")]
        [DisplayFormat(DataFormatString = "{0:N0}",
            ApplyFormatInEditMode = true)]
        [RegularExpression(@"[0-9]", ErrorMessage ="Solo numeros enteros")]
        public decimal precioxComensal { get; set; }

        [Display(Name = "Categor�a")]
        public virtual Categoria Categoria { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Reserva> Reserva { get; set; }
    }
}
