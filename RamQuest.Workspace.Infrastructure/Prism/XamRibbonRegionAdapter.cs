using Infragistics.Windows.Ribbon;
using Prism.Regions;

namespace RamQuest.Workspace.Infrastructure.Prism
{
    public class XamRibbonRegionAdapter : RegionAdapterBase<XamRibbon>
    {
        public XamRibbonRegionAdapter(IRegionBehaviorFactory factory)
            : base(factory) { }

        protected override void Adapt(IRegion region, XamRibbon regionTarget)
        {
            region.ActiveViews.CollectionChanged += ((sender, args) =>
            {
                switch (args.Action)
                {
                    case System.Collections.Specialized.NotifyCollectionChangedAction.Add:
                        {
                            foreach (object view in args.NewItems)
                            {
                                AddViewToRegion(view, regionTarget);
                            }
                            break;
                        }

                    case System.Collections.Specialized.NotifyCollectionChangedAction.Remove:
                        {
                            foreach (object view in args.OldItems)
                            {
                                RemoveViewFromRegion(view, regionTarget);
                            }
                            break;
                        }
                }
            });
        }

        protected override IRegion CreateRegion()
        {
            return new AllActiveRegion();
        }

        private void AddViewToRegion(object view, XamRibbon ribbon)
        {
            var item = view as RibbonTabItem;
            if (item != null)
                ribbon.Tabs.Add(item);
        }

        private void RemoveViewFromRegion(object view, XamRibbon ribbon)
        {
            var item = view as RibbonTabItem;
            if (item != null)
                ribbon.Tabs.Remove(item);
        }

    }
}
