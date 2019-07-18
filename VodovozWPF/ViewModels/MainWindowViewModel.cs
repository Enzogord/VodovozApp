using System.Collections.ObjectModel;
using QS.DomainModel.Entity;
using VodovozWPF.Infrastructure.ViewModels;
using VodovozWPF.ViewModels.Toolbars;

namespace VodovozWPF.ViewModels
{
    public class MainWindowViewModel : PropertyChangedBase
    {
        private ObservableCollection<TabItemViewModel> tabs;
        public ObservableCollection<TabItemViewModel> Tabs {
            get => tabs;
            set => SetField(ref tabs, value, () => Tabs);
        }

        public MainWindowViewModel()
        {
            Tabs = new ObservableCollection<TabItemViewModel>();
            Tabs.Add(new TabItemViewModel() { Header = "Вкладка"});
            Tabs.Add(new TabItemViewModel() { Header = "Вкладка2" });
            Tabs.Add(new TabItemViewModel() { Header = "Вкладка3" });
        }

        private OrdersToolbarViewModel ordersToolbar;
        public OrdersToolbarViewModel OrdersToolbar {
            get => ordersToolbar;
            set => SetField(ref ordersToolbar, value, () => OrdersToolbar);
        }
    }
}
