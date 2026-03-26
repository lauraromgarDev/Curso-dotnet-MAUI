using PatriarcaHomes02.ViewModels;

namespace PatriarcaHomes02.Views;

public partial class ReservasMainView : ContentPage
{
    public ReservasMainView(ReservasMainViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
        viewModel.Navigation = Navigation;
    }

}