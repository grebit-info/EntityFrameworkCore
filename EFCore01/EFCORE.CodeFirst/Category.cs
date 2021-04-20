using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCORE.CodeFirst
{
    public class Category
    {
        public int CategoryId { get; set; } //PK

        public string Name { get; set; }       

        //1: many relation: navigation property
        public ICollection<Product> Products { get; set; }

    }
}
