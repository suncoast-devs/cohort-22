using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TacoTuesday.Models;
using TacoTuesday.Utils;

namespace TacoTuesday.Controllers
{
    // View Model
    //
    // Exists outside the database and in this case
    // only used by this controller. The purpose is
    // to have an object that can see the email and
    // the password for the session we are creating
    public class LoginUser
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    // All of these routes will be at the base URL:     /api/Sessions
    // That is what "api/[controller]" means below. It uses the name of the controller
    // in this case RestaurantsController to determine the URL
    [Route("api/[controller]")]
    [ApiController]
    public class SessionsController : ControllerBase
    {
        // This is the variable you use to have access to your database
        private readonly DatabaseContext _context;

        readonly protected string JWT_KEY;

        // Constructor that receives a reference to your database context
        // and stores it in _context_ for you to use in your API methods
        public SessionsController(DatabaseContext context, IConfiguration config)
        {
            _context = context;
            JWT_KEY = config["JWT_KEY"];
        }

        // POST (CREATE SESSION => Logging In)
        [HttpPost]
        public async Task<ActionResult> Login(LoginUser loginUser)
        {
            var foundUser = await _context.Users.FirstOrDefaultAsync(user => user.Email == loginUser.Email);

            if (foundUser != null && foundUser.IsValidPassword(loginUser.Password))
            {
                // create a custom response
                var response = new
                {
                    // This is the login token
                    token = new TokenGenerator(JWT_KEY).TokenFor(foundUser),

                    // The is the user details
                    user = foundUser
                };

                return Ok(response);
            }
            else
            {
                // Make a custom error response
                var response = new
                {
                    status = 400,
                    errors = new List<string>() { foundUser == null ? "User does not exist" : $"Wrong password: {foundUser.FullName}" }
                };

                // Return our error with the custom response
                return BadRequest(response);
            }
        }
    }
}