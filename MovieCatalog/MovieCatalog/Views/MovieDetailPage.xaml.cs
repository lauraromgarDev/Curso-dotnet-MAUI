namespace MovieCatalog.Views
{
    // 'partial' vincula este código C# con el diseño visual definido en MovieDetailPage.xaml
    public partial class MovieDetailPage : ContentPage
    {
        // CONSTRUCTOR: Recibe como parámetro el "cerebro" (ViewModel) de la película seleccionada.
        // Esto permite que la página sepa exactamente qué película mostrar (Inception, Avatar, etc.)
        public MovieDetailPage(ViewModels.MovieViewModel movie)
        {
            // 1. ASIGNACIÓN DEL CONTEXTO: 
            // Conectamos los datos de la película recibida con la interfaz de usuario.
            // Gracias a esto, en el XAML podremos poner {Binding Title} y funcionará.
            BindingContext = movie;

            // 2. INICIALIZACIÓN: 
            // Carga los elementos visuales (botones, etiquetas, imágenes) definidos en el XAML.
            InitializeComponent();
        }
    }
}