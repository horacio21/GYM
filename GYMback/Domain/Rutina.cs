using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class Rutina
    {
        [Key]
        public int RutinaId { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [MaxLength(50, ErrorMessage = "The Minimun Length for field {0} is {1} characters")]
        [Index("Rutina_Nombre_Index", IsUnique = true)]
        [Display(Name = "Rutina")]
        public string Nombre { get; set; }

        public string Descripcion { get; set; }
    }
}
