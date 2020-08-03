using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tabs
{
    public interface ITabsController
    {
        IEnumerable<ITab> Tabs { get; }
        ITab SelectedTab { get; }
        ITabViewModel SelectedTabViewModel { get; }
        void SwitchTo(ITabViewModel tabViewModel);
        void OpenTab(ITabViewModel tabViewModel);
        void OpenTab(ITabViewModelFactory tabViewModelFactory);
        void AddTab(ITabViewModel tabViewModel);
        void AddTab(ITabViewModelFactory tabViewModelFactory);
    }
}
