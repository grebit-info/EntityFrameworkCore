using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore01.DataAnnotation
{
    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BookId { get; set; }
        [Column(TypeName ="varchar (50)")]
        [Required]
        public int Name { get; set; }
        [ForeignKey("BookCategory")]
        [Required]
        public int Cid { get; set; }
        [NotMapped]
        public string Description { get; set; }

        public virtual BookCategory BookCategory { get; set; }
    }

    [Table("BCategory")]
    public class BookCategory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoryId { get; set; }

        [Column(TypeName = "varchar (50)")]
        [Required]
        public int Name { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}

    
