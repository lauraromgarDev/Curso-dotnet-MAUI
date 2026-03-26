using PatriarcaHomes02.ViewModels;

namespace PatriarcaHomes02.Views;

public partial class ReservaView : ContentPage
{
    public ReservaView(ReservaFormViewModel viewModel)
    {
        InitializeComponent();
        viewModel.Navigation = Navigation; //para que pueda volver atras
        BindingContext = viewModel;

    }
}