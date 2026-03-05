namespace MovieCatalog.Views;

public partial class MoviesListPage : ContentPage
{
    public MoviesListPage()
    {
        // Carga el diseño XAML (botones, listas, etc.)
        InitializeComponent();
    }

    // EVENTO: SE EJECUTA AL TOCAR UNA PELÍCULA EN LA LISTA
    private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        // 1. EXTRAER EL DATO: 'e.Item' es un objeto genérico. 
        // Lo convertimos (cast) a MovieViewModel para poder usarlo.
        ViewModels.MovieViewModel movie = (ViewModels.MovieViewModel)e.Item;

        // 2. NAVEGAR: Abrimos la página de detalles y le pasamos 
        // la película que acabamos de extraer.
        await Navigation.PushAsync(new Views.MovieDetailPage(movie));
    }

    // EVENTO: SE EJECUTA AL PULSAR EL BOTÓN "DELETE" (MENÚ CONTEXTUAL)
    private void MenuItem_Clicked(object sender, EventArgs e)
    {
        // 1. IDENTIFICAR EL BOTÓN: 'sender' es el MenuItem que el usuario pulsó.
        MenuItem menuItem = (MenuItem)sender;

        // 2. BUSCAR EL DATO: El MenuItem "sabe" a qué película pertenece 
        // gracias a su BindingContext. Lo extraemos.
        ViewModels.MovieViewModel movie = (ViewModels.MovieViewModel)menuItem.BindingContext;

        // 3. BORRAR: Llamamos al ViewModel principal (el que tiene la lista completa)
        // para que elimine esta película de la colección.
        // El '?' asegura que no falle si por alguna razón el ViewModel fuera nulo.
        App.MainViewModel?.DeleteMovie(movie);
    }
}