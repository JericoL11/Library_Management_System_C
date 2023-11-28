using Library_Management_System_C.Data;
using Microsoft.AspNetCore.Mvc;
//model class declaration
using Library_Management_System_C.Models;
using Library_Management_System_C.Services;

namespace Library_Management_System_C.Controllers
{
    public class LoginController : Controller
    {
        //user fullname property
        public string Fullname { get; set; }

        //dapendcy injection
        private readonly Library_Management_System_CContext _context;

        public LoginController(Library_Management_System_CContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }



        [HttpPost]
        public IActionResult LoginAct([Bind("Username, Password")] User user)
        {

            //Hashing Passowrd 
            string HashPassword = HashingService.HashData(user.Password);
            //Get the original  password
            user.Password = HashPassword;   


            user.confirm_Password = HashPassword;
            //Link to Database 
            User loginuser = _context.User.Where(u => u.Username == user.Username && u.Password ==user.Password).FirstOrDefault();

            //Verification
            if(loginuser == null)
            {
                ModelState.AddModelError("", "Incorrect Username or Password");
                return View("Index", user);
            }
            else
            {
               //Set Session
                HttpContext.Session.SetString("Fullname",  $"{loginuser.FirstName} {loginuser.LastName}");

                return RedirectToAction("Index", "Users"/*,new { loginuser.id }*/);
           
            }
        }
    }
}
