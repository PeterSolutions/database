using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
    public class LoansJournal
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LoansID { get; set; }
        public int UserID { get; set; }
        [ForeignKey(nameof(UserID))]
        public virtual User User { get; set; } // Asume la existencia de un modelo User


        public int BookID { get; set; }
        [ForeignKey(nameof(BookID))]
        public virtual Book Book { get; set; } // Referencia a un solo libro
        public DateTime LoanDate { get; set; }
        public DateTime? ReturnDate { get; set; }        
    }
}
