using System.ComponentModel.DataAnnotations;

namespace Library_Management_System_C.Models
{
    public class Borrower
    {
        [Key]
        public int borrowerId { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string borrower_fname { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string borrower_lname { get; set; }
        [Required]
        [Display(Name = "Course")]
        public string borrower_Course { get; set; }

        [Required]
        [Phone]
        [MaxLength(11)]
        [Display(Name = "Phone number")]
        public string borrower_PhoneNumber { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string borrower_Email { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime date_registered { get; set; }
    }
}
