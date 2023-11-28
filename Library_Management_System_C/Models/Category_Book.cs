using System.ComponentModel.DataAnnotations;

namespace Library_Management_System_C.Models
{
    public class Category_Book
    {
        [Key]
        [Display(Name ="Category ID")]
        public int categoryId { get; set; }

        [Display(Name = "Category Name")]
        public string categoryName { get; set; }
    }
}
