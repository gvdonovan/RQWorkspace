using Infragistics.Windows.OutlookBar;
using RamQuest.Workspace.Infrastructure;
using RamQuest.Workspace.Modules.ShippingServices.ViewModels;

namespace RamQuest.Workspace.Modules.ShippingServices.Views
{
    /// <summary>
    /// Interaction logic for ShippingServicesGroup.xaml
    /// </summary>
    public partial class ShippingServicesGroup : OutlookBarGroup, IOutlookBarGroup
    {
        public ShippingServicesGroup(ShippingServicesGroupViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }

        public string DefaultNavigationPath
        {
            get
            {
                var item = treeView.SelectionSettings.SelectedNodes[0];

                return item != null ? ((INavigationItem)item.Data).NavigationPath : typeof(Default).FullName;
            }
        }
    }
}
