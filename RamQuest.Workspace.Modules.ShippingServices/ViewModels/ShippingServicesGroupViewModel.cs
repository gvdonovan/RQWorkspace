using System;
using System.Collections.ObjectModel;
using Prism.Regions;
using RamQuest.Workspace.Infrastructure;
using RamQuest.Workspace.Modules.ShippingServices.Views;

namespace RamQuest.Workspace.Modules.ShippingServices.ViewModels
{
    public class ShippingServicesGroupViewModel : ViewModelBase
    {
        private ObservableCollection<NavigationItem> _items;
        public ObservableCollection<NavigationItem> Items
        {
            get { return _items; }
            set
            {
                _items = value;
                OnPropertyChanged("Items");
            }
        }

        public ShippingServicesGroupViewModel()
        {
            GenerateMenu();
        }

        private void GenerateMenu()
        {
            Items = new ObservableCollection<NavigationItem>();

            var root = new NavigationItem() { Caption = "Billing", NavigationPath = typeof(RamQuest.Workspace.Modules.ShippingServices.Views.Default).FullName };
            root.Items.Add(new NavigationItem() { Caption = "FedEx", NavigationPath = CreateNavigationPath(MenuFolders.FedEx, typeof(A)) });
            root.Items.Add(new NavigationItem() { Caption = "UPS", NavigationPath = CreateNavigationPath(MenuFolders.Ups, typeof(B)) });
            Items.Add(root);
        }

        private static string CreateNavigationPath(string folder, Type t)
        {
            var query = new NavigationParameters {{MenuFolders.FolderKey, folder}};
            return t.FullName + query;
        }
    }
}
