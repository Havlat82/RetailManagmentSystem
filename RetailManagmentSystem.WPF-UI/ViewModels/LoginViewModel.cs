using Caliburn.Micro;
using RetailManagmentSystem.WPF_UI.Helpers;
using System;
using System.Threading.Tasks;

namespace RetailManagmentSystem.WPF_UI.ViewModels
{
    public class LoginViewModel : Screen
    {
        private string _username;
        private string _password;
        private IAPIHelper _apiHelper;

        public LoginViewModel(IAPIHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }

        public string Username
        {
            get
            {
                return _username;
            }
            set
            {
                _username = value;
                NotifyOfPropertyChange(() => Username);
                NotifyOfPropertyChange(() => CanLogIn);
            }
        }

        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                NotifyOfPropertyChange(() => Password);
                NotifyOfPropertyChange(() => CanLogIn);
            }
        }

        public bool CanLogIn
        {
            get
            {
                return !String.IsNullOrEmpty(Username) && !String.IsNullOrEmpty(Password);
            }
        }

        public async Task LogIn()
        {
            try
            {
                var result = await _apiHelper.Authenticate(Username, Password);
            }
            catch (Exception ex)
            {
                var message = ex.Message;

            }
        }
    }
}
