using CommunityToolkit.Mvvm.ComponentModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GW2R_Medical_Associates.Maui.ViewModels
{
    public partial class BaseViewModel : ObservableObject
    {
        [ObservableProperty]
        string title;

        [ObservableProperty]
        bool isLoading;

        public bool IsNotLoading => !isLoading;
    }
}
