using RetailManagmentSystem.WPF_UI.Models;
using System.Threading.Tasks;

namespace RetailManagmentSystem.WPF_UI.Helpers
{
    public interface IAPIHelper
    {
        Task<AuthenticatedUser> Authenticate(string username, string password);
    }
}