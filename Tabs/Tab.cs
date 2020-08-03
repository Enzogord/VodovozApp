using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tabs
{
    public class Tab : ITab, INotifyPropertyChanged
    {
        internal ObservableCollection<Tab> ObservableTabs { get; } = new ObservableCollection<Tab>();
        private readonly TabsController tabsController;

        private ITabViewModel tabViewModel;
        public ITabViewModel TabViewModel {
            get => tabViewModel;
            private set {
                tabViewModel = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TabViewModel)));
            }
        }

        public Tab(ITabViewModel tabViewModel, TabsController tabsController)
        {
            TabViewModel = tabViewModel ?? throw new ArgumentNullException(nameof(tabViewModel));
            this.tabsController = tabsController ?? throw new ArgumentNullException(nameof(tabsController));
        }

        public IEnumerable<Tab> GetAllTabs()
        {
            return ObservableTabs.SelectMany(x => x.GetAllTabs());
        }

        #region INotifyPropertyChanged implementation

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion INotifyPropertyChanged implementation

        #region ITab implementation

        public string Name => TabViewModel.TabName;
        public string HashName => TabViewModel.TabHashName;
        public IEnumerable<ITab> Tabs => ObservableTabs;
        public event EventHandler OnClose;

        public void Close()
        {
            OnClose?.Invoke(this, EventArgs.Empty);
        }

        public void OpenSlaveTab(ITabViewModel tabViewModel)
        {
            if(tabsController.SwitchIfExist(tabViewModel)) {
                return;
            }
            if(tabsController.TryCreateTab(tabViewModel, out Tab tab)) {
                tab.OnClose += (s, e) => RemoveTab(tab);
                ObservableTabs.Add(tab);
            }
        }        

        public void OpenSlaveTab(ITabViewModelFactory tabViewModelFactory)
        {
            if(tabViewModelFactory == null) {
                return;
            }
            OpenSlaveTab(tabViewModelFactory.CreateViewModel());
        }

        public void OpenTab(ITabViewModel tabViewModel)
        {
            tabsController.OpenNewTab(tabViewModel);
        }

        public void OpenTab(ITabViewModelFactory tabViewModelFactory)
        {
            tabsController.OpenNewTab(tabViewModelFactory);
        }

        #endregion ITab implementation

        private void RemoveTab(Tab tab)
        {
            if(ObservableTabs.Contains(tab)) {
                ObservableTabs.Remove(tab);
            }
        }
    }
}
