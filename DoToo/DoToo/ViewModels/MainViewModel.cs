using DoToo.Repositories;


namespace DoToo.ViewModels
{
    public class MainViewModel : ViewModel
    {
        // Esto es un ejemplo de cómo inyectar el repositorio en el ViewModel.
        // En una aplicación real, podrías usar un contenedor de inyección de
        // dependencias para manejar esto.
        private readonly ITodoItemRepository repository;

        // Constructor que recibe el repositorio como parámetro.
        public MainViewModel(ITodoItemRepository repository)
        {
            this.repository = repository;
            Task.Run(async () => await LoadDataAsync());
        }

        private async Task LoadDataAsync()
        {
        }
    }
}
