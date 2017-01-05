using System.Windows;
using System.Windows.Input;
using Infragistics.Controls.Menus;

namespace RamQuest.Workspace.Infrastructure.Prism
{
    public class XamDataTreeItemSelected                 
    {
        private static readonly DependencyProperty SelectedCommandBehaviorProperty = DependencyProperty.RegisterAttached("SelectedCommandBehavior", typeof(XamDataTreeCommandBehavior), typeof(XamDataTreeItemSelected), null);

        public static readonly DependencyProperty CommandProperty = DependencyProperty.RegisterAttached("Command", typeof(ICommand), typeof(XamDataTreeItemSelected), new PropertyMetadata(OnSetCommandCallback));
        public static ICommand GetCommand(XamDataTree menuItem)
        {
            return menuItem.GetValue(CommandProperty) as ICommand;
        }

        public static void SetCommand(XamDataTree menuItem, ICommand command)
        {
            menuItem.SetValue(CommandProperty, command);
        }

        private static void OnSetCommandCallback(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {
            var menuItem = dependencyObject as XamDataTree;
            if (menuItem != null)
            {
                var behavior = GetOrCreateBehavior(menuItem);
                behavior.Command = e.NewValue as ICommand;
            }
        }

        private static XamDataTreeCommandBehavior GetOrCreateBehavior(XamDataTree menuItem)
        {
            var behavior = menuItem.GetValue(SelectedCommandBehaviorProperty) as XamDataTreeCommandBehavior;
            if (behavior == null)
            {
                behavior = new XamDataTreeCommandBehavior(menuItem);
                menuItem.SetValue(SelectedCommandBehaviorProperty, behavior);
            }

            return behavior;
        }
    }
}
