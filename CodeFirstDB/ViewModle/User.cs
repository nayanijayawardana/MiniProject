using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CodeFirstDB.ViewModle
{
    public class User
    {
        [Column("UserId")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int UserId { get; set; }

        [Column("UserName")]
        [Required]
        [StringLength(50)]
        public string UserName { get; set; }

        [Column("NIC")]
        [Required]
        [StringLength(10)]
        public string NIC { get; set; }

        [Column("Age")]
        [Required]
        public Int64 Age { get; set; }

    }
}
