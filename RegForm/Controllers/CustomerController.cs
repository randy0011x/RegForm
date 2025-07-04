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
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(UserModel user)
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
