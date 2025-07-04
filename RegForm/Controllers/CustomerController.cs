using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RegForm.Data;
using RegForm.HttpClients;
using RegForm.Models;

namespace RegForm.Controllers
{
    public class CustomerController : Controller

    {
        private readonly ApplicationDbContext _context;
        private readonly UserClient _userClient;
        public CustomerController(ApplicationDbContext context, UserClient userclient)
        {
            _context = context;
            _userClient = userclient;
        }

        //public IActionResult Index() // TO DISPLAY THE LIST OF USER
        //{
        //    var users = _context.Users.ToList(); // TO DISPLAY FROM CODE
        //    return View(users);
        //}
        public async Task<IActionResult> Index()
        {
            var users = await _userClient.GetUsersAsync();
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
