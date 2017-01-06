using System;
using Prism.Commands;
using Prism.Events;
using Prism.Interactivity.InteractionRequest;
using Prism.Regions;
using RamQuest.Workspace.Infrastructure;

namespace RamQuest.Workspace.Modules.ShippingServices.ViewModels
{
    public interface IAViewModel : IViewModel { }
    public class AViewModel : NavigationAwareViewModelBase, IAViewModel
    {
        private readonly IRegionManager _regionManager;
        private readonly IEventAggregator _eventAggregator;

        public DelegateCommand<string> NavigateCommand { get; private set; }

        private readonly InteractionRequest<Confirmation> confirmExitInteractionRequest;

        public AViewModel(IRegionManager regionManager, IEventAggregator eventAggregator)
        {
            _regionManager = regionManager;
            _eventAggregator = eventAggregator;
            NavigateCommand = new DelegateCommand<string>(Navigate);
            confirmExitInteractionRequest = new InteractionRequest<Confirmation>();
        }        

        private void Navigate(string obj)
        {
            var parameters = new NavigationParameters {{"Folder", obj}};
            _regionManager.RequestNavigate(RegionNames.ContentRegion, new Uri("A", UriKind.Relative), parameters);
        }

        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            if (navigationContext == null) throw new ArgumentNullException(nameof(navigationContext));
            Title = $"{navigationContext.Parameters[MenuFolders.FolderKey]}";
            base.OnNavigatedTo(navigationContext);
            _eventAggregator.GetEvent<ViewActivateEvent>().Publish(Title);
        }

        public IInteractionRequest ConfirmExitInteractionRequest
        {
            get { return this.confirmExitInteractionRequest; }
        }

        public override void ConfirmNavigationRequest(NavigationContext navigationContext, Action<bool> continuationCallback)
        {
            var b = true;
            if (b)
            {
                confirmExitInteractionRequest.Raise(
                    new Confirmation {Content = "Foo", Title = "Bar"},
                    c => { continuationCallback(c.Confirmed); });
            }
            continuationCallback(true);
        }
    }
}
