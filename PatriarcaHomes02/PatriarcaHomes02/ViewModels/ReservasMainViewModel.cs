using CommunityToolkit.Mvvm.Input;
using PatriarcaHomes02.Models;
using PatriarcaHomes02.Repositories;
using PatriarcaHomes02.Views;

using System.Collections.ObjectModel;
using System.Diagnostics;

namespace PatriarcaHomes02.ViewModels
{
    public partial class ReservasMainViewModel : ViewModel
    {
        private readonly IReservaRepository _repository;
        private readonly IServiceProvider _services;


        //esto es lo que va a escuchar la vista
        public ObservableCollection<ReservaItemViewModel> ReservasItems { get; set; }


        public ReservasMainViewModel(IReservaRepository repository, IServiceProvider services)
        {
            this._repository = repository;
            this._services = services;

            ReservasItems = new ObservableCollection<ReservaItemViewModel>();

            //metodos para recargar la pg con las noticias cuando añadamos una reserva
            _repository.OnReservaAdded -= AlAnadirReserva;
            _repository.OnReservaAdded += AlAnadirReserva;
            _repository.OnReservaUpdated += AlAnadirReserva;

            //al arrancar las pedimos
            _ = CargarReservas();
        }

        //metodo para recargar la pag cuando creamos
        private void AlAnadirReserva(object sender, Reserva nuevaReserva)
        {
            MainThread.BeginInvokeOnMainThread(async () =>
            {
                await CargarReservas();
            });
        }



        [RelayCommand]
        private async Task CargarReservas()
        {
            try
            {
                // Pedimos los datos  al Repositorio (vía ApiService)
                var datosDeLaravel = await _repository.GetReservasAsync();

                // Limpiamos la lista actual
                ReservasItems.Clear();

                // Transformamos cada Reserva en un "envoltorio" ItemViewModel
                foreach (var reserva in datosDeLaravel)
                {
                    var item = new ReservaItemViewModel(reserva);
                    ReservasItems.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error al cargar: {ex.Message}");
            }
        }

        [RelayCommand]
        public async Task AddReserva()
        {
            await Navigation.PushAsync(_services.GetRequiredService<ReservaView>());
        }

        [RelayCommand]
        public async Task SeleccionarReserva(ReservaItemViewModel itemCargado)
        {
            if (itemCargado == null) return;
            //Debug.Write(itemCargado);

            // Obtener la página del formulario
            var view = _services.GetRequiredService<ReservaView>();
            var vm = view.BindingContext as ReservaFormViewModel;

            // Esto rellena el formulario con la reserva que ya existe
            vm.Item = itemCargado.Reserva;

            await Navigation.PushAsync(view);

        }
    }
}
