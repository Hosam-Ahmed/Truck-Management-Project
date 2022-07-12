using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FinalProject.Models.DB
{
    internal class CustomerDetails
    {
        [Key]
        public int PersonId { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string Telephone { get; set; }
        public int CustomerId { get; set; }
        public string LicenseNumber { get; set; }
        public int Age { get; set; }
        public DateTime LicenseExpiryDate { get; set; }
    }
}
