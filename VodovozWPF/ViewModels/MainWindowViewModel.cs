using System.Collections.ObjectModel;
using QS.DomainModel.Entity;
using VodovozWPF.Infrastructure.ViewModels;
using VodovozWPF.Properties;

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
            Tabs.Add(new TabItemViewModel() { Header = "Заказы",        Image = Resources.orders        });
            Tabs.Add(new TabItemViewModel() { Header = "Логистика",     Image = Resources.logistic      });
            Tabs.Add(new TabItemViewModel() { Header = "Склад",         Image = Resources.stock         });
            Tabs.Add(new TabItemViewModel() { Header = "Касса",         Image = Resources.cash          });
            Tabs.Add(new TabItemViewModel() { Header = "Бухгалтерия",   Image = Resources.accounting    });
            Tabs.Add(new TabItemViewModel() { Header = "Архив",         Image = Resources.archive       });
            Tabs.Add(new TabItemViewModel() { Header = "Работа с кл.",  Image = Resources.crm           });
        }
    }
}
