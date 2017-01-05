using Infragistics.Windows.OutlookBar;
using Prism.Regions;

namespace RamQuest.Workspace.Infrastructure.Prism
{
    public class XamOutlookBarRegionAdapter : RegionAdapterBase<XamOutlookBar>
    {
        public XamOutlookBarRegionAdapter(IRegionBehaviorFactory factory)
            : base(factory) { }

        protected override void Adapt(IRegion region, XamOutlookBar regionTarget)
        {
            region.ActiveViews.CollectionChanged += ((sender, args) =>
            {
                switch (args.Action)
                {
                    case System.Collections.Specialized.NotifyCollectionChangedAction.Add:
                        {
                            foreach (OutlookBarGroup group in args.NewItems)
                            {
                                regionTarget.Groups.Add(group);

                                if (regionTarget.Groups[0] == group)
                                {
                                    regionTarget.SelectedGroup = group;
                                }
                            }
                            break;
                        }

                    case System.Collections.Specialized.NotifyCollectionChangedAction.Remove:
                        {
                            foreach (OutlookBarGroup group in args.OldItems)
                            {
                                regionTarget.Groups.Remove(group);
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
    }
}
