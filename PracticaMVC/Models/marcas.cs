using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PracticaMVC.Models
{
    public class marcas
    {
        [Key]
        public int id_marcas { get; set; }

        [Display (Name = "Nombre marca")]
        public string? nombre_marca { get; set; }

        [Display(Name = "Estado")]
        public string? estados { get; set; }
    }
}
