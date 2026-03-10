using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DoToo.Models;
using DoToo.Repositories;
using DoToo.Views;
using System.Collections.ObjectModel;


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
            repository.OnItemAdded += (sender, item) =>
                items.Add(CreateTodoItemViewModel(item));
            repository.OnItemUpdated += (sender, item) =>
                Task.Run(async () => await LoadDataAsync());

            this.repository = repository;
            this.services = services;
            Task.Run(async () => await LoadDataAsync());

        }

        private async Task LoadDataAsync()
        {
            var items = await repository.GetItemsAsync();

            var itemViewModels = items.Select(i =>
                CreateTodoItemViewModel(i));
            Items = new ObservableCollection<TodoItemViewModel>(itemViewModels);

        }
        private TodoItemViewModel CreateTodoItemViewModel(TodoItem item)
        {
            var itemViewModel = new TodoItemViewModel(item);
            itemViewModel.ItemStatusChanged += ItemStatusChanged;
            return itemViewModel;
        }
        private void ItemStatusChanged(object sender, EventArgs e)
        {
        }

        [RelayCommand]
        public async Task AddItemAsync() =>
               await Navigation.PushAsync(services.GetRequiredService<ItemView>());

        [ObservableProperty]
        ObservableCollection<TodoItemViewModel> items;


        [ObservableProperty]
        TodoItemViewModel selectedItem;

        partial void OnSelectedItemChanging(TodoItemViewModel value)
        {
            if (value == null)
            {
                return;
            }

            MainThread.BeginInvokeOnMainThread(async () =>
            {
                await NavigateToItemAsync(value);
            });
        }

        private async Task NavigateToItemAsync(TodoItemViewModel item)
        {
            var itemView = services.GetRequiredService<ItemView>();
            var vm = itemView.BindingContext as ItemViewModel;

            vm.Item = item.Item;
            itemView.Title = "Edit to do item";

            await Navigation.PushAsync(itemView);
        }
    }
}
