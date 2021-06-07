using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CodeFirstDB.ViewModle
{
    public class Book
    {
        [Column("BookId")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int BookId { get; set; }

        [Column("ISBN")]
        [Required]
        [StringLength(50)]
        public string ISBN { get; set; }
        

        [Column("Title")]
        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        [Column("Description")]
        [Required]
        [StringLength(500)]
        public string Description { get; set; }

        [Column("Status")]
        //DatabaseGenerated(DatabaseGeneratedOption.DEFAULT 1)]
        [Required]
        public Boolean Status { get; set; } = true;
       

    }
}
