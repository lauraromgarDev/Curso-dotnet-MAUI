using PatriarcaHomes02.Models;
using PatriarcaHomes02.Services;

namespace PatriarcaHomes02.Repositories
{
    public class ReservaRepository : IReservaRepository
    {
        private readonly ApiService _apiService;

        // El constructor recibe el ApiService (Inyección de Dependencias)
        public ReservaRepository(ApiService apiService)
        {
            _apiService = apiService;
        }


        public event EventHandler<Reserva> OnReservaAdded;



        public async Task<List<Reserva>> GetReservasAsync()
        {
            try
            {
                // Llamamos al método genérico de tu ApiService.
                // "reservas" es el endpoint de tu API en Laravel (api/reservas)
                var resultado = await _apiService.GetAsync<List<Reserva>>("reservas");

                // Si viene nulo, devolvemos una lista vacía para no romper la app
                return resultado ?? new List<Reserva>();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error en Repositorio: {ex.Message}");
                return new List<Reserva>();
            }
        }


        public Task AddOrUpdateAsync(Reserva reserva)
        {
            throw new NotImplementedException();
        }

        public Task AddReservaAsync(Reserva reserva)
        {
            throw new NotImplementedException();
        }

        public Task deleteReservaAsync(Reserva reserva)
        {
            throw new NotImplementedException();
        }



        public Task UpdateReservaAsync(Reserva reserva)
        {
            throw new NotImplementedException();
        }
    }
}
