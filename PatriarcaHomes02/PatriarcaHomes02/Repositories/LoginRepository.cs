using PatriarcaHomes02.Models;
using PatriarcaHomes02.Services;
using System.Diagnostics;

namespace PatriarcaHomes02.Repositories
{
    public class LoginRepository : ILoginRepository
    {

        private readonly ApiService _apiService;
        public LoginRepository(ApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<bool> LoginAsync(string email, string password)
        {
            var datosLogin = new { email = email, password = password };

            // Llamamos al POST de  ApiService
            var resultado = await _apiService.PostAsync<LoginResponse>("login", datosLogin);

            if (resultado != null && !string.IsNullOrEmpty(resultado.AccessToken))
            {
                // Guardamos el token
                await SecureStorage.Default.SetAsync("auth_token", resultado.AccessToken);

                // Avisamos al ApiService que ya tenemos token 
                return true;
            }
            return false;
        }


        public async Task<bool> LogoutAsync()
        {
            try
            {
                // 1. Avisamos a Laravel 
                await _apiService.PostAsync<object>("logout", new { });

                // 2. Borramos el token del dispositivo SIEMPRE 
                SecureStorage.Default.Remove("auth_token");

                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error en Logout: {ex.Message}");
                // Si hay error de red, borramos el token igual para que el usuario pueda salir
                SecureStorage.Default.Remove("auth_token");
                return false;
            }
        }
    }
}
