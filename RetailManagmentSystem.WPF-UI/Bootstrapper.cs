using Caliburn.Micro;
using RetailManagmentSystem.WPF_UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace RetailManagmentSystem.WPF_UI
{
    public class Bootstrapper : BootstrapperBase
    {
        private SimpleContainer _container = new SimpleContainer();

        public Bootstrapper()
        {
            Initialize();
        }

        protected override void Configure()
        {
            _container.Instance(_container);

            _container.Singleton<IWindowManager, WindowManager>()
                      .Singleton<IEventAggregator, EventAggregator>();

            GetType().Assembly.GetTypes()
                              .Where(type => type.IsClass && type.Name.EndsWith("ViewModel"))
                              .ToList()
                              .ForEach(viewModelType => _container.RegisterPerRequest(
                                  viewModelType, viewModelType.ToString(), viewModelType));
        }

        protected async override void OnStartup(object sender, StartupEventArgs e)
        {
            await DisplayRootViewForAsync<ShellViewModel>();
        }

        protected override object GetInstance(Type service, string key)
        {
            return _container.GetInstance(service, key);
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return _container.GetAllInstances(service);
        }

        protected override void BuildUp(object instance)
        {
            _container.BuildUp(instance);
        }


    }
}
