using System.Collections.Generic;

namespace RamQuest.Workspace.Infrastructure
{
    public interface IViewBase
    {
        IViewModel ViewModel { get; set; }
        IList<IRibbonTabItem> RibbonTabs { get; }
    }
}
