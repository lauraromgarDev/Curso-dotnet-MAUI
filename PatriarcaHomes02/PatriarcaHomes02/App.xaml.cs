using PatriarcaHomes02.Views;

namespace PatriarcaHomes02;

public partial class App : Application
{
    private readonly IServiceProvider _services;

    public App(IServiceProvider services)
    {
        InitializeComponent();
        _services = services;
    }

    protected override Window CreateWindow(IActivationState? activationState)
    {
        // 1. Verificamos si ya hay un token (Auto-Login)
        // Usamos una tarea síncrona para decidir la raíz
        var token = Task.Run(async () => await SecureStorage.Default.GetAsync("auth_token")).Result;

        if (!string.IsNullOrEmpty(token))
        {
            // Usuario ya logueado -> Entramos al Shell
            return new Window(_services.GetRequiredService<AppShell>());
        }

        // Usuario no logueado -> Vamos al Login (envuelto en NavigationPage para transiciones)
        var loginPage = _services.GetRequiredService<LoginView>();
        return new Window(new NavigationPage(loginPage));
    }
}