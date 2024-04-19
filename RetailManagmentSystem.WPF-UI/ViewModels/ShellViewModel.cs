using Caliburn.Micro;

namespace RetailManagmentSystem.WPF_UI.ViewModels
{
    public class ShellViewModel : Conductor<object>
    {
        private LoginViewModel _loginViewModel;

        public ShellViewModel(LoginViewModel loginViewModel)
        {
            _loginViewModel = loginViewModel;
            ActivateLoginViewModel();
        }

        private async void ActivateLoginViewModel()
        {
            await ActivateItemAsync(_loginViewModel);
        }
    }
}
