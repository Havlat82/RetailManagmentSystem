using Caliburn.Micro;
using RetailManagmentSystem.WPF_UI.EventModels;
using System.Threading;
using System.Threading.Tasks;

namespace RetailManagmentSystem.WPF_UI.ViewModels
{
    public class ShellViewModel : Conductor<object>, IHandle<LogOnEvent>
    {
        private IEventAggregator _eventAggregator;
        private SalesViewModel _salesViewModel;
        private SimpleContainer _simpleContainer;

        public ShellViewModel(IEventAggregator eventAggregator,
                              SalesViewModel salesViewModel,
                              SimpleContainer simpleContainer)
        {
            _eventAggregator = eventAggregator;
            _salesViewModel = salesViewModel;
            _simpleContainer = simpleContainer;

            _eventAggregator.SubscribeOnPublishedThread(this);
            ActivateLoginViewModel();
        }

        public async Task HandleAsync(LogOnEvent message, CancellationToken cancellationToken)
        {
            await ActivateItemAsync(_salesViewModel);

        }

        private async void ActivateLoginViewModel()
        {
            await ActivateItemAsync(_simpleContainer.GetInstance<LoginViewModel>());
        }
    }
}
