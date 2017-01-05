using System;

namespace RamQuest.Workspace.Infrastructure
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class RibbonTabAttribute : Attribute
    {
        public Type Type { get; private set; }

        public RibbonTabAttribute(Type ribbonTabType)
        {
            if (ribbonTabType == null) throw new ArgumentNullException(nameof(ribbonTabType));
            if (ribbonTabType.BaseType != typeof(RibbonTabItem))
                throw new ArgumentOutOfRangeException(nameof(ribbonTabType), "Ribbon Tab Type does not derive from RibbonTabItem");
            Type = ribbonTabType;
        }
    }

}
