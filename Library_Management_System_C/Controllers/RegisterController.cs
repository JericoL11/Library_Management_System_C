using Library_Management_System_C.Data;
using Library_Management_System_C.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

//hash library
using Library_Management_System_C.Services;

namespace Library_Management_System_C.Controllers
{
    public class RegisterController : Controller
    {
        private readonly Library_Management_System_CContext _context;

        public RegisterController(Library_Management_System_CContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,FirstName,LastName,Username,Password,confirm_Password,BirthDate")] User user)
        {
            //Hashing Passowrd
            string HashPassword = HashingService.HashData(user.Password);
            //assiging of password column to database
             user.Password = HashPassword;
            user.confirm_Password = HashPassword;

            if (ModelState.IsValid)
            {
                _context.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

    }
}
