using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FinalProject.Models.DB
{
    internal class EmployeeDetails
    {
        [Key]
        public int PersonId { get; set; }

        public int EmployeeId { get; set; }
        public string Name { get; set; }

        public string Address { get; set; }

        public string Telephone { get; set; }

        public string OfficeAddress { get; set; }

        public string PhoneExtensionNumber { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Role { get; set; }
    }
}
