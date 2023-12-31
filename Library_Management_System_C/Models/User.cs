﻿using System.ComponentModel.DataAnnotations;

namespace Library_Management_System_C.Models
{
    public class User
    {
        
        //Model Properties
        [Key]
        public int id { get; set; }

        [Required(ErrorMessage = "Enter your First name")]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "Enter your Last name")]
        public string? LastName { get; set; }

        [Required(ErrorMessage = "Enter a Username")]
        public string? Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
        [Required(ErrorMessage = "Password is required")]

        [DataType(DataType.Password)]
        [Display(Name ="Confirm Password")]
        [Compare("Password")]
        public string? confirm_Password  { get; set; } 

        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
    }
}
