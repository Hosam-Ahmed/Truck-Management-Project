using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace FinalProject.Models.DB
{
    public class TruckEditDetails
    {
        [Key]
        public int TruckId { get; set; }
        public string Colour { get; set; } = null!;
        public string RegistrationNumber { get; set; } = null!;
        public DateTime WofexpiryDate { get; set; }
        public DateTime RegistrationExpiryDate { get; set; }
        public decimal DailyRentalPrice { get; set; }
        public decimal AdvanceDepositRequired { get; set; }
        public int Seats { get; set; }
        public string Model { get; set; } = null!;
        public string? Status { get; set; } = null!;
        public string Description { get; set; }






    }
}
