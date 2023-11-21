using Library_Management_System_C.Data;
using Microsoft.AspNetCore.Mvc;
//model class declaration
using Library_Management_System_C.Models;
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
                //assigning of property
                Fullname = $"{loginuser.FirstName} {loginuser.LastName}";

                return RedirectToAction("Index", "Users"/*,new { loginuser.id }*/);
           
            }
        }
    }
}
