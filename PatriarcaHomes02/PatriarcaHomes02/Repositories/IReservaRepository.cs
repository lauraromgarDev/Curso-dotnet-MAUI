using PatriarcaHomes02.Models;


namespace PatriarcaHomes02.Repositories
{
    public interface IReservaRepository
    {
        //metodo que avisa a la vista cuando uan reserva cambie
        event EventHandler<Reserva> OnReservaAdded;

        //definimos los metodos base
        Task<List<Reserva>> GetReservasAsync();
        Task AddReservaAsync(Reserva reserva);
        Task UpdateReservaAsync(Reserva reserva);
        Task AddOrUpdateAsync(Reserva reserva);
        Task deleteReservaAsync(Reserva reserva);
    }
}
