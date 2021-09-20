using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace SampleApp.Controllers
{
    public abstract class AuthorizedController : ControllerBase
    {
        // Protected helper method to get the JWT claim related to the user Id
        protected int GetCurrentUserId()
        {
            // Get the User Id from the claim and then parse it as an integer.
            return int.Parse(User.Claims.FirstOrDefault(claim => claim.Type == "Id").Value);
        }
    }
}
