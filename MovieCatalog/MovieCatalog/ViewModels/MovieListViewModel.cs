using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;


namespace MovieCatalog.ViewModels
{

    // 'ObservableObject' permite que la interfaz de usuario se entere de los cambios.
    public class MovieListViewModel : ObservableObject
    {
        private MovieViewModel _selectedMovie;

        // Propiedad pública que el CollectionView "mira" para saber cuál está marcada.
        // Al usar 'SetProperty', si cambia la selección, la página de detalles se entera al instante.
        public MovieViewModel SelectedMovie
        {
            get => _selectedMovie;
            set => SetProperty(ref _selectedMovie, value);
        }



        // 'ObservableCollection' es una lista especial para MAUI: 
        // Si añades o quitas un elemento aquí, la pantalla se actualiza SOLA.
        // Usa 'MovieViewModel' porque es el diseño de CADA película individual.
        public ObservableCollection<MovieViewModel> Movies { get; set; }

        // CONSTRUCTOR:
        public MovieListViewModel()
        {
            // Inicializamos la lista vacía usando la sintaxis moderna '[]'.
            Movies = [];
        }

        // MÉTODO PARA CARGAR DATOS:
        // Es 'async' para que la app no se bloquee mientras lee el JSON.
        public async Task RefreshMovies()
        {
            // 1. Llamamos a la "Base de Datos" (el lector del JSON) que creamos antes.
            IEnumerable<Models.Movie> moviesData = await Models.MoviesDatabase.GetMovies();

            // 2. Por cada película pura del JSON (Models.Movie), 
            // creamos un "Envoltorio Visual" (MovieViewModel) y lo metemos en la lista.
            foreach (Models.Movie movie in moviesData)
                Movies.Add(new MovieViewModel(movie));
        }

        // MÉTODO PARA BORRAR:
        // Al usar 'Movies.Remove', el elemento desaparece de la pantalla automáticamente
        // gracias a la magia de la ObservableCollection.
        public void DeleteMovie(MovieViewModel movie) =>
            Movies.Remove(movie);
    }
}
