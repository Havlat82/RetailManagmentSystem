using RetailManagmentSystem.WPF_UI.Library.Models;
using System.Threading.Tasks;

namespace RetailManagmentSystem.WPF_UI.Library.Api
{
    public interface IAPIHelper
    {
        Task<AuthenticatedUser> Authenticate(string username, string password);
        Task<LoggedInUserModel> GetLoggedInUserInfo(string token);
    }
}