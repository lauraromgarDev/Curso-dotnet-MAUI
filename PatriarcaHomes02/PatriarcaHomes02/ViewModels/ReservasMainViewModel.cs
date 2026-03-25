using PatriarcaHomes02.Models;
using PatriarcaHomes02.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;

namespace PatriarcaHomes02.ViewModels
{
    public partial class ReservasMainViewModel : ViewModel
    {
        private readonly IReservaRepository _repository;

        //esto es lo que va a escuchar la vista
        public ObservableCollection<ReservaItemViewModel> ReservasItems { get; set; }

        public ReservasMainViewModel(IReservaRepository repository)
        {
            this._repository = repository;

            ReservasItems = new ObservableCollection<ReservaItemViewModel>();

            //al arrancar las pedimos
            _ = CargarReservas();
        }


        private async Task CargarReservas_()
        {
            try
            {
                // 1. Pedimos los datos
                var datosLaravel = await _repository.GetReservasAsync();

                // 2. Actualizamos la lista en el hilo principal
                MainThread.BeginInvokeOnMainThread(() =>
                {
                    ReservasItems.Clear();

                    if (datosLaravel != null && datosLaravel.Count > 0)
                    {
                        foreach (var reserva in datosLaravel)
                        {
                            // Cada reserva se envuelve en su ItemViewModel
                            var item = new ReservaItemViewModel(reserva);
                            ReservasItems.Add(item);
                        }
                    }
                });
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error al cargar: {ex.Message}");
            }
        }
        private async Task CargarReservas()
        {
            try
            {
                // 1. Pedimos los datos puros al Repositorio (vía ApiService)
                var datosDeLaravel = await _repository.GetReservasAsync();

                // 2. Limpiamos la lista actual
                ReservasItems.Clear();

                // 3. Transformamos cada Reserva en un "envoltorio" ItemViewModel
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
    }
}
