using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FinalProject.Models.DB
{
    internal class PersonInformation
    {
        [Key]
        public int PersonId { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string Telephone { get; set; }
    }
}
