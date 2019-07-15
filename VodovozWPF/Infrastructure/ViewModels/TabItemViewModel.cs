using System.Drawing;
using QS.DomainModel.Entity;
using QS.ViewModels;

namespace VodovozWPF.Infrastructure.ViewModels
{
    public class TabItemViewModel : PropertyChangedBase
    {  
        private string header;
        public string Header {
            get => header;
            set => SetField(ref header, value, () => Header);
        }
    }
}
