using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tabs
{
    public class TabsController : ITabsController, INotifyPropertyChanged
    {
        private readonly List<Tab> rootTabs = new List<Tab>();
        private IEnumerable<Tab> allTabs;

        private void UpdateTabs()
        {
            allTabs = rootTabs.SelectMany(x => x.GetAllTabs());
            RaisePropertyChanged(nameof(Tabs));
        }

        private Tab selectedTab;
        public ITab SelectedTab => selectedTab;

        internal bool TryCreateTab(ITabViewModel tabViewModel, out Tab tab)
        {
            tab = null;
            if(tabViewModel == null) {
                return false;
            }
            var existedTab = allTabs.FirstOrDefault(x => x.HashName == tabViewModel.TabHashName);
            if(existedTab != null) {
                return false;
            }
            tab = new Tab(tabViewModel, this);
            return true;
        }

        internal bool SwitchIfExist(ITabViewModel tabViewModel)
        {
            if(tabViewModel == null) {
                return false;
            }
            var existedTab = allTabs.FirstOrDefault(x => x.HashName == tabViewModel.TabHashName);
            if(existedTab == null) {
                return false;
            }
            SwitchTo(existedTab);
            return true;
        }

        private void SwitchTo(Tab tab)
        {
            if(tab == null || !allTabs.Any(x => x.HashName == tab.HashName)) {
                return;
            }
            selectedTab = tab;
            SelectedTabViewModel = selectedTab.TabViewModel;
            RaisePropertyChanged(nameof(SelectedTab));
        }

        public void SwitchTo(ITab tab)
        {
            if(tab == null) {
                return;
            }
            var existedTab = allTabs.FirstOrDefault(x => x.HashName == tab.HashName);
            if(existedTab == null) {
                return;
            }
            SwitchTo(existedTab);
        }

        public void SwitchTo(ITabViewModel tabViewModel)
        {
            SwitchIfExist(tabViewModel);
        }

        #region INotifyPropertyChanged implementation

        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion INotifyPropertyChanged implementation

        #region ITabsController implementation

        public IEnumerable<ITab> Tabs => allTabs;

        private ITabViewModel selectedTabViewModel;
        public ITabViewModel SelectedTabViewModel {
            get => selectedTabViewModel;
            set {
                selectedTabViewModel = value;
                RaisePropertyChanged(nameof(SelectedTabViewModel));
            }
        }

        public void OpenNewTab(ITabViewModel tabViewModel)
        {
            if(tabViewModel == null) {
                return;
            }
            if(SwitchIfExist(tabViewModel)) {
                return;
            }
            if(TryCreateTab(tabViewModel, out Tab newTab)) {
                rootTabs.Add(newTab);
                newTab.OnTabsChanged += NewTab_OnTabsChanged;
            }
            UpdateTabs();
        }

        private void NewTab_OnTabsChanged(object sender, EventArgs e)
        {
            UpdateTabs();
        }

        public void OpenNewTab(ITabViewModelFactory tabViewModelFactory)
        {
            if(tabViewModelFactory == null) {
                return;
            }
            OpenNewTab(tabViewModelFactory.CreateViewModel());
        }

        #endregion ITabsController implementation
    }
}
