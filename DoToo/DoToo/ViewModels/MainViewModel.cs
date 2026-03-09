using CommunityToolkit.Mvvm.Input;
using DoToo.Repositories;
using DoToo.Views;


namespace DoToo.ViewModels
{
    public partial class MainViewModel : ViewModel
    {

        private readonly ITodoItemRepository repository;

        //Este es un ejemplo de cómo inyectar el servicio de navegación en el ViewModel.
        private readonly IServiceProvider services;

        // Constructor que recibe el repositorio y el servicio de navegación.
        public MainViewModel(ITodoItemRepository repository, IServiceProvider services)
        {
            this.repository = repository;
            this.services = services;
            Task.Run(async () => await LoadDataAsync());

        }

        private async Task LoadDataAsync()
        {
        }

        [RelayCommand]
        public async Task AddItemAsync() =>
               await Navigation.PushAsync(services.GetRequiredService<ItemView>());
    }
}
