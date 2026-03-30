
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PatriarcaHomes02.Repositories;
using System.Diagnostics;
using static PatriarcaHomes02.Models.LoginResponse;

namespace PatriarcaHomes02.ViewModels
{
    public partial class LoginViewModel : ViewModel
    {
        private readonly ILoginRepository _loginRepository;
        private readonly IServiceProvider _serviceProvider;

        [ObservableProperty]
        string email;

        [ObservableProperty]
        string password;

        public LoginViewModel(ILoginRepository loginRepository, IServiceProvider serviceProvider)
        {
            _loginRepository = loginRepository;
            _serviceProvider = serviceProvider;
        }

        [RelayCommand]
        public async Task AccesoApp_()
        {
            //Debug.WriteLine("¡Botón pulsado!");

            if (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Password))
            {
                // Forma universal para MAUI
                await Application.Current.MainPage.DisplayAlertAsync("Error", "Rellena todos los campos", "OK"); return;
            }

            bool exito = await _loginRepository.LoginAsync(Email, Password);

            if (exito)
            {
                // ¡Adentro! Vamos a la lista de reservas
                Application.Current.MainPage = _serviceProvider.GetRequiredService<AppShell>();
            }
            else
            {
                await Application.Current.MainPage.DisplayAlertAsync("Error", "Email o contraseña incorrectos", "OK");
            }
        }



        [RelayCommand]
        public async Task LogoutApp()
        {
            // 1. Llamamos al repositorio para limpiar el token
            await _loginRepository.LogoutAsync();

            // 2. CAMBIO DE RAÍZ: Volvemos a la LoginView
            // Importante usar el ServiceProvider para obtener la instancia correcta
            var loginPage = _serviceProvider.GetRequiredService<Views.LoginView>();

            // Envolvemos en NavigationPage por si quieres usar navegaciones dentro del Login
            Application.Current.MainPage = new NavigationPage(loginPage);
        }
    }
}
