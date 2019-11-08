using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DesarrolloTallerMecanico.Models.Data.DDL
{
    public class Mecanico
    {
        public int Id { get; set; }

        [Required]

        public string Nombres { get; set; }

        [Required]

        public string Apellidos { get; set; }

        [Required]

        public string DPI { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaContratacion { get; set; }
        [Required]

        public string Email { get; set; }

    }
}
