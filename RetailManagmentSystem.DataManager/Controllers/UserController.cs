using Microsoft.AspNet.Identity;
using RetailManagmentSystem.DataManagerLibrary.DataAccess;
using RetailManagmentSystem.DataManagerLibrary.Models;
using System.Linq;
using System.Web.Http;

namespace RetailManagmentSystem.DataManager.Controllers
{
    [Authorize]
    [RoutePrefix("api/User")]
    public class UserController : ApiController
    {
        [HttpGet]
        public UserModel GetById()
        {
            var userId = RequestContext.Principal.Identity.GetUserId();
            var data = new UserData();
            return data.GetUserById(userId).First();
        }
    }
}