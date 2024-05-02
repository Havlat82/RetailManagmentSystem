using Caliburn.Micro;
using RetailManagmentSystem.WPF_UI.EventModels;
using RetailManagmentSystem.WPF_UI.Library.Api;
using System;
using System.Threading.Tasks;

namespace RetailManagmentSystem.WPF_UI.ViewModels
{
    public class LoginViewModel : Screen
    {
        private string _username;
        private string _password;
        private string _errorMessage;
        private IAPIHelper _apiHelper;
        private IEventAggregator _eventAggregator;

        public LoginViewModel(IAPIHelper apiHelper, IEventAggregator eventAggregator)
        {
            _apiHelper = apiHelper;
            _eventAggregator = eventAggregator;
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

        public bool IsErrorVisible
        {
            get
            {
                return !string.IsNullOrEmpty(ErrorMessage);
            }

        }

        public string ErrorMessage
        {
            get
            {
                return _errorMessage;
            }
            set
            {
                _errorMessage = value;
                NotifyOfPropertyChange(() => ErrorMessage);
                NotifyOfPropertyChange(() => IsErrorVisible);
            }
        }

        public bool CanLogIn
        {
            get
            {
                return !string.IsNullOrEmpty(Username) && !string.IsNullOrEmpty(Password);
            }
        }

        public async Task LogIn()
        {
            ErrorMessage = "";

            try
            {
                var result = await _apiHelper.Authenticate(Username, Password);
                ErrorMessage = "Jsi přihlášen";
                await _apiHelper.GetLoggedInUserInfo(result.Access_Token);
                await _eventAggregator.PublishOnUIThreadAsync(new LogOnEvent());

            }
            catch (Exception ex)
            {
                ErrorMessage = $"Nejsi přihlášen: {ex.Message}";
            }

        }
    }
}
