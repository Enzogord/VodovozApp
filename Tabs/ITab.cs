using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tabs
{
    public interface ITab
    {
        string Name { get; }
        string HashName { get; }
        IEnumerable<ITab> Tabs { get; }
        ITabViewModel ITabViewModel { get; set; }

        event EventHandler OnClose;
        void Close();
        void OpenTab(ITabViewModel tabViewModel);
        void OpenTab(ITabViewModelFactory tabViewModelFactory);
        void AddTab(ITabViewModel tabViewModel);
        void AddTab(ITabViewModelFactory tabViewModelFactory);
        void OpenSlaveTab(ITabViewModel tabViewModel);
        void OpenSlaveTab(ITabViewModelFactory tabViewModelFactory);
        void AddSlaveTab(ITabViewModel tabViewModel);
        void AddSlaveTab(ITabViewModelFactory tabViewModelFactory);
    }

    public class MyClass
    {
        public string TestString { get; set; }

        public override bool Equals(object obj)
        {
            return obj is MyClass @class &&
                   TestString == @class.TestString;
        }

        public override int GetHashCode()
        {
            return -368777640 + EqualityComparer<string>.Default.GetHashCode(TestString);
        }
    }
}