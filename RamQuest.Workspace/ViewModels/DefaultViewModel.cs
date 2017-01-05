using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RamQuest.Workspace.Infrastructure;

namespace RamQuest.Workspace.ViewModels
{
    public interface IDefaultViewModel : IViewModel { }

    public class DefaultViewModel : IDefaultViewModel
    {
        public string Title { get; set; }
    }
}
