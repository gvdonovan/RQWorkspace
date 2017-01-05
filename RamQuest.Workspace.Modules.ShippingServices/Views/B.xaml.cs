using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Prism.Events;
using Prism.Regions;
using RamQuest.Workspace.Modules.ShippingServices.ViewModels;

namespace RamQuest.Workspace.Modules.ShippingServices.Views
{
    /// <summary>
    /// Interaction logic for B.xaml
    /// </summary>
    public partial class B
    {
        public B(IBViewModel viewModel, IRegionManager regionManager, IEventAggregator eventAggregator)
            : base(viewModel, regionManager, eventAggregator)
        {
            InitializeComponent();
        }
    }
}
