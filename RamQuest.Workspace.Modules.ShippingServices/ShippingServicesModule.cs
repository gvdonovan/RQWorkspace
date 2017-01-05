using Prism.Regions;
using Microsoft.Practices.Unity;
using RamQuest.Workspace.Infrastructure;
using RamQuest.Workspace.Infrastructure.Prism;
using RamQuest.Workspace.Modules.ShippingServices.ViewModels;
using RamQuest.Workspace.Modules.ShippingServices.Views;

namespace RamQuest.Workspace.Modules.ShippingServices
{
    public class ShippingServicesModule : ModuleBase
    {        

        public ShippingServicesModule(IUnityContainer container, IRegionManager regionManager)
            : base(container, regionManager)
        {            
        }

        protected override void RegisterTypes()
        {
            Container.RegisterTypeForNavigation<Default>();
            Container.RegisterTypeForNavigation<A>();
            Container.RegisterTypeForNavigation<B>();

            Container.RegisterType<IDefaultViewModel, DefaultViewModel>();
            Container.RegisterType<IAViewModel, AViewModel>();
            Container.RegisterType<IBViewModel, BViewModel>();
        }

        protected override void ResolveOutlookGroups()
        {
            RegionManager.Regions[RegionNames.OutlookBarRegion].Add(Container.Resolve<ShippingServicesGroup>());
        }
    }
}