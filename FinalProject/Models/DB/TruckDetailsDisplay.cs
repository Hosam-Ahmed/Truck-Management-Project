using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FinalProject.Models.DB
{

    public class TruckDetailsDisplay
    {
        [Key]
        public int TruckId { get; set; }
        public string Model { get; set; } = null!;
        public string Colour { get; set; } = null!;
        public decimal DailyRentalPrice { get; set; }
        public string Size { get; set; } = null!;
        public string? Status { get; set; } = null!;

        public int FeatureId { get; set; }
        public string Description { get; set; }




    }
}
