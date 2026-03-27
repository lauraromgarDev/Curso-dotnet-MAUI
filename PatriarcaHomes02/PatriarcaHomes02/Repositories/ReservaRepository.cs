using PatriarcaHomes02.Models;
using PatriarcaHomes02.Services;
using System.Diagnostics;

namespace PatriarcaHomes02.Repositories
{
    public class ReservaRepository : IReservaRepository
    {
        private readonly ApiService _apiService;

        // El constructor recibe el ApiService 
        public ReservaRepository(ApiService apiService)
        {
            _apiService = apiService;
        }


        public event EventHandler<Reserva> OnReservaAdded;
        public event EventHandler<Reserva> OnReservaUpdated;



        public async Task<List<Reserva>> GetReservasAsync()
        {
            try
            {
                // Llamamos al método genérico de ApiService.
                // "reservas" es el endpoint de la API en Laravel 
                var resultado = await _apiService.GetAsync<List<Reserva>>("reservas");

                // Si viene nulo, devolvemos una lista vaciap
                return resultado ?? new List<Reserva>();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error en Repositorio: {ex.Message}");
                return new List<Reserva>();
            }
        }


        public async Task AddOrUpdateAsync(Reserva reserva)
        {
            if (reserva.Id == 0)
            {
                await AddReservaAsync(reserva);
            }
            else
            {
                await UpdateReservaAsync(reserva);
            }
        }

        public async Task AddReservaAsync(Reserva nuevaReserva)
        {
            try
            {
                var resultado = await _apiService.PostAsync<Reserva>("reservas/store", nuevaReserva);

                if (resultado != null)
                {
                    OnReservaAdded?.Invoke(this, resultado);
                }
                else
                {
                    Debug.WriteLine("Error: La API no devolvió nada o hubo un error 4xx/5xx.");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Excepción al guardar: {ex.Message}");
            }
        }



        public async Task UpdateReservaAsync(Reserva reserva)
        {
            try
            {
                string endpoint = $"reservas/update/{reserva.Id}";

                var resultado = await _apiService.PutAsync<Reserva>(endpoint, reserva);

                if (resultado != null)
                {
                    // Lanzamos el evento para que la lista se entere
                    OnReservaUpdated?.Invoke(this, resultado);
                    Debug.WriteLine("Reserva actualizada correctamente en Laravel");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error al actualizar: {ex.Message}");
            }
        }


        public Task deleteReservaAsync(Reserva reserva)
        {
            throw new NotImplementedException();
        }

    }
}
