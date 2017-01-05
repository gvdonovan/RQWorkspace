using Microsoft.Practices.Unity;
using Prism.Unity;
using System.Windows;
using Infragistics.Windows.OutlookBar;
using Infragistics.Windows.Ribbon;
using Prism.Modularity;
using Prism.Regions;
using RamQuest.Workspace.Infrastructure.Prism;
using RamQuest.Workspace.Modules.ShippingServices;
using RamQuest.Workspace.Views;

namespace RamQuest.Workspace
{
    class Bootstrapper : UnityBootstrapper
    {
        protected override System.Windows.DependencyObject CreateShell()
        {
            return Container.Resolve<Shell>();
        }

        protected override void InitializeShell()
        {
            base.InitializeShell();

            Application.Current.MainWindow = (Window)Shell;
            Application.Current.MainWindow.Show();
        }

        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();
        }

        protected override Prism.Modularity.IModuleCatalog CreateModuleCatalog()
        {
            //return base.CreateModuleCatalog();

            var catalog = new ModuleCatalog();
            catalog.AddModule(typeof(ShippingServicesModule));
            //catalog.AddModule(typeof(MailModule));
            //catalog.AddModule(typeof(MarketMakerModule));
            return catalog;
        }

        protected override Prism.Regions.RegionAdapterMappings ConfigureRegionAdapterMappings()
        {
            var mappings = base.ConfigureRegionAdapterMappings();
            mappings.RegisterMapping(typeof(XamOutlookBar), Container.TryResolve<XamOutlookBarRegionAdapter>());
            mappings.RegisterMapping(typeof(XamRibbon), Container.TryResolve<XamRibbonRegionAdapter>());
            return mappings;
        }

        protected override IRegionBehaviorFactory ConfigureDefaultRegionBehaviors()
        {
            var behaviors = base.ConfigureDefaultRegionBehaviors();
            behaviors.AddIfMissing(XamRibbonRegionBehavior.BehaviorKey, typeof(XamRibbonRegionBehavior));
            return behaviors;
        }
    }    
}