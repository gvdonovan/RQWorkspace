using Infragistics.Windows.Ribbon;
using RamQuest.Workspace.Infrastructure;
using RamQuest.Workspace.ViewModels;

namespace RamQuest.Workspace.Views
{
    /// <summary>
    /// Interaction logic for Shell.xaml
    /// </summary>
    public partial class Shell : XamRibbonWindow
    {
        public Shell(ShellViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;

        }

        private void OnOutlookBarGroupChanging(object sender, Infragistics.Windows.OutlookBar.Events.SelectedGroupChangingEventArgs e)
        {
            var group = e.NewSelectedOutlookBarGroup as IOutlookBarGroup;
            if (group != null)
            {
                Commands.NavigateCommand.Execute(group.DefaultNavigationPath);
            }
        }
    }
}