using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCORE.CodeFirst
{
   public class Product
    {

        public int ProductId { get; set; } //PK

        public string Name { get; set; }

        [Column(TypeName ="varchar (100)")]
        [Required]
        public string Description { get; set; }

        public string Image { get; set; }

        public int CategoryId { get; set; } // FK



        // 1:1 relaton
        public Category Category { get; set; }

    }
}
