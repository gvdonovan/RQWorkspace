using System;
using Prism.Commands;
using Prism.Events;
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

        public AViewModel(IRegionManager regionManager, IEventAggregator eventAggregator)
        {
            _regionManager = regionManager;
            _eventAggregator = eventAggregator;
            NavigateCommand = new DelegateCommand<string>(Navigate);         
        }        

        private void Navigate(string obj)
        {
            var parameters = new NavigationParameters {{"Folder", obj}};
            _regionManager.RequestNavigate(RegionNames.ContentRegion, new Uri("A", UriKind.Relative), parameters);
        }

        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            if (navigationContext == null) throw new ArgumentNullException(nameof(navigationContext));
            if (navigationContext == null) throw new ArgumentNullException(nameof(navigationContext));
            Title = $"{navigationContext.Parameters[MenuFolders.FolderKey]}";
            base.OnNavigatedTo(navigationContext);
            _eventAggregator.GetEvent<ViewActivateEvent>().Publish(Title);
        }
    }
}
