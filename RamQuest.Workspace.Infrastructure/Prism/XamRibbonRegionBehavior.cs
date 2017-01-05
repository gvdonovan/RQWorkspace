using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using Prism.Regions;

namespace RamQuest.Workspace.Infrastructure.Prism
{
    public class XamRibbonRegionBehavior : RegionBehavior
    {
        public const String BehaviorKey = "XamRibbonRegionBehavior";

        protected override void OnAttach()
        {
            if (Region.Name == RegionNames.ContentRegion)
                Region.ActiveViews.CollectionChanged += OnActiveViewsCollectionChanged;
        }

        private void OnActiveViewsCollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                Boolean isFirst = true;
                foreach (var newView in e.NewItems)
                {
                    //make sure we are dealing with the right type of view
                    var view = newView as IViewBase;
                    if (view == null)
                        continue;

                    //if we already have ribbons no need on checking again
                    if (view.RibbonTabs.Count > 0)
                        continue;

                    //loop through all the ribbon tab attributes and create them for the view
                    foreach (var atr in GetCustomAttributes<RibbonTabAttribute>(newView.GetType()))
                    {
                        var ribbonTab = (IRibbonTabItem)Activator.CreateInstance(atr.Type);
                        ribbonTab.ViewModel = view.ViewModel;

                        view.RibbonTabs.Add(ribbonTab);
                        ribbonTab.IsSelected = isFirst;

                        if (isFirst)
                            isFirst = false;
                    }
                }
            }
        }

        IEnumerable<T> GetCustomAttributes<T>(Type type)
        {
            return type.GetCustomAttributes(typeof(T), true).OfType<T>();
        }
    }
}
