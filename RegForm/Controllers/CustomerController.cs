using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RegForm.Data;
using RegForm.Models;

namespace RegForm.Controllers
{
    public class CustomerController : Controller

    {
        private readonly ApplicationDbContext _context;
        public CustomerController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index() // TO DISPLAY THE LIST OF USER
        {
            var users = _context.Users.ToList();
            return View(users);
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(UserModel user) // TO CREATE A NEW USER I.E REGISTER() IS JUST A PAGE RENDERING ACTION, CREATE IS AN ACTION TO CREATE A NEW USER
        {
            if (ModelState.IsValid)
            {
                _context.Users.Add(user);
                _context.SaveChanges();
                return RedirectToAction("Index","Customer");
            }
            return View("Register", user);
        }
    }
}
