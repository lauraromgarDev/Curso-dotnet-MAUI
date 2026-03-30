using PatriarcaHomes02.ViewModels;
using PatriarcaHomes02.Views;

namespace PatriarcaHomes02
{
    public partial class AppShell : Shell
    {
        public AppShell(LoginViewModel viewModel) // Inyectamos el ViewModel
        {
            InitializeComponent();
            BindingContext = viewModel; // <--- Sin esto, el botón de Logout no hará nada

            // Registro de rutas extra si las necesitas
            Routing.RegisterRoute(nameof(ReservasMainView), typeof(ReservasMainView));
        }
    }
}
