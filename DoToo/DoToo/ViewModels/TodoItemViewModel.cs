using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DoToo.Models;


namespace DoToo.ViewModels
{
    public partial class TodoItemViewModel : ViewModel
    {
        // El constructor recibe un TodoItem
        // y lo asigna a la propiedad Item.
        public TodoItemViewModel(TodoItem item) => Item = item;

        // Este evento se dispara cuando el estado del item cambia.
        public event EventHandler ItemStatusChanged;
        [ObservableProperty]

        TodoItem item;

        // Este método se llama para cambiar el estado del item.
        public string StatusText => Item.Completed ? "Reactivate" :
        "Completed";

        [RelayCommand]
        void ToggleCompleted()
        {
            Item.Completed = !Item.Completed;
            ItemStatusChanged?.Invoke(this, new EventArgs());
        }
    }
}
