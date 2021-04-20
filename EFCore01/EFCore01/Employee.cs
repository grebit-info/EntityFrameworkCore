using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore01
{
   public  class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        [Column(TypeName ="varchar (225)")]
        [Required]
        public string Name { get; set; }
        // public string Address { get; set; }
        [Column(TypeName = "varchar (12)")]
        [Required]
        public string PhoneNumber { get; set; }



    }
}
