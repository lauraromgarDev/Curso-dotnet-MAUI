using CommunityToolkit.Mvvm.ComponentModel;
using System;

namespace MovieCatalog.ViewModels
{
    // Esta clase representa UNA SOLA película en la pantalla.
    // Hereda de ObservableObject para poder avisar a la interfaz cuando algo cambie.
    public class MovieViewModel : ObservableObject
    {
        // CAMPOS PRIVADOS (Backing fields): 
        // Aquí se guarda el valor real en memoria.
        private string _title;
        private string _studio;
        private string _director;
        private DateOnly _year;

        // PROPIEDADES PÚBLICAS: 
        // Es lo que el XAML "lee" para mostrar en la pantalla.
        public string Title
        {
            get => _title;
            // 'SetProperty' hace tres cosas: 
            // 1. Comprueba si el valor es nuevo.
            // 2. Si es nuevo, lo guarda en _title.
            // 3. ¡Grita! Avisa a la pantalla para que se refresque el texto.
            set => SetProperty(ref _title, value);
        }

        public string Studio
        {
            get => _studio;
            set => SetProperty(ref _studio, value);
        }

        public string Director
        {
            get => _director;
            set => SetProperty(ref _director, value);
        }

        public DateOnly Year
        {
            get => _year;
            set => SetProperty(ref _year, value);
        }

        // CONSTRUCTOR:
        // Recibe el 'record' (el ingrediente bruto) y rellena este ViewModel (el plato preparado).
        public MovieViewModel(Models.Movie movie)
        {
            Title = movie.Title;
            Studio = movie.Studio;
            Director = movie.Director;

            // Transformación: Convertimos el número 2024 en una fecha real (1 de enero de 2024).
            // Esto permite, por ejemplo, aplicar formatos de fecha en la interfaz.
            _year = new DateOnly(movie.Year, 1, 1);
        }
    }
}