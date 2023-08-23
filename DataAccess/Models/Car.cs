using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class Car
    {
        public int CarId { get; set; }
        public int VehicleCategoryId { get; set; }
        [Required]
        public string Brand { get; set; } = string.Empty;
        [Required]
        public string Model { get; set; } = string.Empty;
        [MaxLength(500)]
        public string Description { get; set; } = string.Empty;
        [Required]
        [MaxLength(20)]
        [DisplayName("Plate Number")]
        public string PlateNumber { get; set; } = string.Empty;
        public string ImgUrl { get; set; } = "https://upload.wikimedia.org/wikipedia/commons/1/1d/Opel_Kadett_C_Coupe.jpg";
    }
}
