using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Library_Management_System_C.Models;

namespace Library_Management_System_C.Data
{
    public class Library_Management_System_CContext : DbContext
    {
        public Library_Management_System_CContext (DbContextOptions<Library_Management_System_CContext> options)
            : base(options)
        {
        }

        public DbSet<Library_Management_System_C.Models.User> User { get; set; } = default!;

        public DbSet<Library_Management_System_C.Models.Books> Books { get; set; } = default!;
        public DbSet<Library_Management_System_C.Models.Category_Book> Category_Book { get; set; } = default!;
    }
}
