using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class VehicleCategory
    {
        public int VehicleCategoryId { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [MaxLength(120)]
        public string Description { get; set; } = string.Empty;
        [Required]
        [DisplayName("Price per day")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double PricePerDay { get; set; }
        virtual public List<Car> Cars { get; set; } = new();
    }
}
