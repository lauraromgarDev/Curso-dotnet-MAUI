using CommunityToolkit.Mvvm.ComponentModel;
using PatriarcaHomes02.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PatriarcaHomes02.ViewModels
{
    public partial class ReservaItemViewModel : ObservableObject
    {
        //
        [ObservableProperty]
        private Reserva reserva; // el toolkit genera una propiedad llamada Reserva que avisa a la vista si algo cambia. Es privada y siempre en mayus

        public ReservaItemViewModel(Reserva reserva)
        {
            this.Reserva = reserva;
        }
    }
}
