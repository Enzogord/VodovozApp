using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tabs
{
    public interface ITabViewModelFactory
    {
        ITabViewModel CreateViewModel();
    }
}
