using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PatriarcaHomes02.Models;
using PatriarcaHomes02.Repositories;
using System.Diagnostics;

namespace PatriarcaHomes02.ViewModels
{
    public partial class ReservaFormViewModel : ViewModel
    {
        private readonly IReservaRepository _repository;

        [ObservableProperty]
        Reserva item; // lo que recibimos de la vista

        public ReservaFormViewModel(IReservaRepository repository)
        {
            _repository = repository;
            Item = new Reserva { Fecha = DateTime.Now };
        }


        [RelayCommand]
        public async Task SaveReservaAsync()
        {
            try
            {
                await _repository.AddOrUpdateAsync(Item);
                await Navigation.PopAsync(); //volvemos atras
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error al guardar la reserva: {ex.Message}");
            }
        }

        [RelayCommand]

        public async Task DeleteReservaAsync()
        {
            try
            {
                await _repository.deleteReservaAsync(Item);
                await Navigation.PopAsync(); //volvemos atras
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error al borrar la reserva: {ex.Message}");
            }
        }
    }
}
