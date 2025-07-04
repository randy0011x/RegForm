using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RegForm.Data;

namespace RegForm.API
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CustomerController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]

        public string test()
        {
            return "API is working fine!"; // Test API endpoint
        }

        [HttpGet]
        public IActionResult GetUsers() // To get the list of users
        {
            var users = _context.Users.ToList();
            return Ok(users);
        }
    }
}
