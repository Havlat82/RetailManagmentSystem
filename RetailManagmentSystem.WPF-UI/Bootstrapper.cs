using Caliburn.Micro;
using RetailManagmentSystem.WPF_UI.ViewModels;
using System.Windows;

namespace RetailManagmentSystem.WPF_UI
{
    public class Bootstrapper : BootstrapperBase
    {
        public Bootstrapper()
        {
            Initialize();
        }

        protected async override void OnStartup(object sender, StartupEventArgs e)
        {
            await DisplayRootViewForAsync<ShellViewModel>();
        }
    }
}
