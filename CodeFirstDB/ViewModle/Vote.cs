using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CodeFirstDB.ViewModle
{

    public class Vote
    {
        [Column("VoteId")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int VoteId { get; set; }

        [ForeignKey("BookID")]
        public virtual Book Book { get; set; }

        [ForeignKey("UserID")]
        public virtual User User { get; set; }

        //public int UserId { get; set; }

        [Column("Value")]
        [Required]
        public int Value { get; set; }



    }

}
