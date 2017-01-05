using RamQuest.Workspace.Infrastructure;

namespace RamQuest.Workspace.Modules.ShippingServices.ViewModels
{
    public interface IDefaultViewModel : IViewModel { }

    public class DefaultViewModel : IDefaultViewModel
    {
        public string Title { get; set; }
    }
}
