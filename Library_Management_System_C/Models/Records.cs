using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Library_Management_System_C.Models
{
    public class Records
    {
        [Key]
        public int record_id { get; set; }

        [Required]
        [Display(Name = "for Borrower")]
        public int borrowerId { get; set; }


        [ForeignKey("borrowerId")]
        [Display(Name = "Full Name")]
        public Borrower? FK_borrower { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime due_date { get; set; }

        [Required]
        [Display(Name = "For Libratian")]
        public int librarianId { get; set; }

        [ForeignKey("librarianId")]
        public User? FK_librarian { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime? transac_date { get; set; }
    }
}
