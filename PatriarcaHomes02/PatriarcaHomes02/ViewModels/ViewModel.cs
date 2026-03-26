
using CommunityToolkit.Mvvm.ComponentModel;

namespace PatriarcaHomes02.ViewModels
{
    [ObservableObject]
    public abstract partial class ViewModel
    {
        public INavigation Navigation { get; set; }
    }
}
