using PatriarcaHomes02.Views;

namespace PatriarcaHomes02;

public partial class App : Application
{
    public App(Views.ReservasMainView mainPage)
    {
        InitializeComponent();
        // Asignación directa
        MainPage = new NavigationPage(mainPage);
    }
}