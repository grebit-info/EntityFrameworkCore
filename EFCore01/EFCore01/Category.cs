using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore01
{
    // Built-in Conventions
    // Naming Conventions
    // Type Conventions (int, string)
    // Primary Key Conventions
    // Relationship Conventions


    // Categories  : as DB Table Name
    public class Category
    {
        public int CategoryId { get; set; } // Primary Key
        public string Name { get; set; }// nvarchar (max)

        // navigation Property: 1-many
        public virtual ICollection<Product> Products { get; set; }

    }

    // Products : as DB Table Name
    public class Product
    {
        public int ProductId { get; set; } // Primary Key
        public string Name { get; set; }// nvarchar (max)
        public string UnitPrice { get; set; } // decimal(18,2)
        public int CategoryId { get; set; } // foreign key

        // navigation Property: 1-1 Mapping
        public virtual Category Category { get; set; } 

    }
}
