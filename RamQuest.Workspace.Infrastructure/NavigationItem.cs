using System.Collections.ObjectModel;

namespace RamQuest.Workspace.Infrastructure
{
    public class NavigationItem : INavigationItem
    {
        public string Caption { get; set; }
        public bool IsExpanded { get; set; }
        public string NavigationPath { get; set; }
        public ObservableCollection<NavigationItem> Items { get; set; }

        public NavigationItem()
        {
            IsExpanded = true;
            Items = new ObservableCollection<NavigationItem>();
        }
    }
}
