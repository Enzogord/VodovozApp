using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using QS.DomainModel.Entity;
using QS.Tabs;

namespace Tabs
{
    public class TabsViewModel : PropertyChangedBase, ITabParent
    {
        private ObservableCollection<TabItemViewModel> observableTabs;
        public ObservableCollection<TabItemViewModel> ObservableTabs {
            get => observableTabs;
            set => SetField(ref observableTabs, value, () => ObservableTabs);
        }

        private string name;
        public string Name {
            get => name;
            set => SetField(ref name, value, () => Name);
        }


        #region ITabParent implementation

        public IEnumerable<ITab> Tabs => ObservableTabs.Select(x => x.Tab);

        public void AddTab(ITab tab)
        {
            if(ObservableTabs == null) {
                ObservableTabs = new ObservableCollection<TabItemViewModel>();
            }
            ObservableTabs.Add(new TabItemViewModel(tab));
        }

        #endregion ITabParent implementation
    }
}
