using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library_Management_System_C.Models
{
    public class Books
    {
        [Key]
       
        public int bookId { get; set; }
        [Required]

        [Display(Name = "Book Name")]
        public string? bookName { get; set; }
        
        [Required]
        [Display(Name = "Author")]
        public string? author { get; set; }

        [Required]
        [Display(Name = "Category ID")]
        public int categoryId { get; set; }

        [ForeignKey("categoryId")]
        public Category_Book? book_category { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Date Added")]
        public DateTime dateAdded { get; set; }

       
    }
}
