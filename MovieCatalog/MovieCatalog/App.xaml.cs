using Microsoft.Extensions.DependencyInjection;

namespace MovieCatalog
{
    // 'partial' indica que esta clase se divide en dos archivos: 
    // este (.cs) y el de diseño visual (.xaml).
    public partial class App : Application
    {
        // PROPIEDAD ESTÁTICA (GLOBAL):
        // Al ser 'static', cualquier página de tu app puede acceder a ella usando 'App.MainViewModel'.
        // El signo '?' indica que puede ser nulo al principio (antes de que se cree la ventana).
        // El 'private set' significa que solo esta clase puede crear el objeto.
        public static ViewModels.MovieListViewModel? MainViewModel { get; private set; }

        // CONSTRUCTOR:
        // Se ejecuta en cuanto la app se carga en memoria.
        public App()
        {
            // Carga los estilos, colores y fuentes definidos en el archivo App.xaml
            InitializeComponent();
        }

        // MÉTODO DE CREACIÓN DE VENTANA:
        // En .NET 10 y VS 2026, este es el punto de entrada oficial para mostrar la interfaz.
        protected override Window CreateWindow(IActivationState? activationState)
        {
            // 1. CREACIÓN DEL NAVEGADOR (SHELL):
            // Creamos una nueva ventana y le asignamos el 'AppShell' como raíz. 
            // El AppShell contiene el menú, las pestañas y la configuración de las páginas.
            var window = new Window(new AppShell());

            // 2. INICIALIZACIÓN DEL VIEWMODEL:
            // Creamos la instancia del "cerebro" que manejará la lógica de las películas.
            MainViewModel = new();

            // 3. CARGA DE DATOS ASÍNCRONA:
            // Llamamos al método para buscar películas (de una API o base de datos).
            // '.ContinueWith' asegura que la app NO se bloquee ni se quede en blanco
            // mientras los datos se están descargando en segundo plano.
            MainViewModel.RefreshMovies().ContinueWith((s) => { });

            // 4. LANZAMIENTO:
            // Devolvemos la ventana ya configurada al sistema operativo (Android, iOS, Windows) para que la dibuje.
            return window;
        }
    }
}