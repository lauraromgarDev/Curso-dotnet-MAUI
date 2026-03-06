namespace MovieCatalog.Views
{
    // 'partial' vincula este código C# con el diseño visual definido en MovieDetailPage.xaml
    public partial class MovieDetailPage : ContentPage
    {
        // CONSTRUCTOR: Recibe como parámetro el "cerebro" (ViewModel) de la película seleccionada.
        // Esto permite que la página sepa exactamente qué película mostrar (Inception, Avatar, etc.)
        public MovieDetailPage()
        {
            BindingContext = App.MainViewModel.SelectedMovie;
            InitializeComponent();
        }
    }
}