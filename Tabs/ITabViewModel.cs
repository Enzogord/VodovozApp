using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tabs
{
    public interface ITabViewModel : INotifyPropertyChanged
    {
        ITab Tab { get; }
        string TabName { get; }
        string TabHashName { get; }
        ITab ITab { get; set; }
    }
}
