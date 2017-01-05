using Infragistics.Controls.Menus;
using Prism.Interactivity;

namespace RamQuest.Workspace.Infrastructure.Prism
{
    public class XamDataTreeCommandBehavior : CommandBehaviorBase<XamDataTree>
    {
        public XamDataTreeCommandBehavior(XamDataTree tree)
            : base(tree)
        {
            tree.ActiveNodeChanged += OnNodeChanged;     
        }

        private void OnNodeChanged(object sender, ActiveNodeChangedEventArgs e)
        {
            var parameter = e.NewActiveTreeNode.Data as INavigationItem;
            
            CommandParameter = parameter != null ? parameter.NavigationPath : string.Empty;

            ExecuteCommand(CommandParameter);
        }
    }
}
