using PatriarcaHomes02.ViewModels;

namespace PatriarcaHomes02.Views;

public partial class LoginView : ContentPage
{
    public LoginView(LoginViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}