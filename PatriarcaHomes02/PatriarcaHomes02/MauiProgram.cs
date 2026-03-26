using PatriarcaHomes02.Repositories;
using PatriarcaHomes02.ViewModels;
using PatriarcaHomes02.Views;
using PatriarcaHomes02.Services;

namespace PatriarcaHomes02;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            })
            .RegisterServices()
            .RegisterViewModels()
            .RegisterViews();

        return builder.Build();
    }

    public static MauiAppBuilder RegisterServices(this MauiAppBuilder mauiAppBuilder)
    {
        // 1. Registro del ApiService (Clase normal)
        mauiAppBuilder.Services.AddSingleton<ApiService>();

        // 2. Registro de Interfaz -> Implementación (Lo que explicaba tu texto)
        // Decimos: "Cuando alguien pida IReservaRepository, dale un ReservaRepository"
        mauiAppBuilder.Services.AddSingleton<IReservaRepository, ReservaRepository>();

        return mauiAppBuilder;
    }

    public static MauiAppBuilder RegisterViewModels(this MauiAppBuilder mauiAppBuilder)
    {
        // Registramos los ViewModels que hemos creado
        mauiAppBuilder.Services.AddTransient<ReservasMainViewModel>();
        mauiAppBuilder.Services.AddTransient<ReservaItemViewModel>();
        mauiAppBuilder.Services.AddTransient<ReservaFormViewModel>();

        return mauiAppBuilder;
    }

    public static MauiAppBuilder RegisterViews(this MauiAppBuilder mauiAppBuilder)
    {
        // Registramos la Vista principal
        mauiAppBuilder.Services.AddTransient<ReservasMainView>();
        mauiAppBuilder.Services.AddTransient<ReservaView>();

        return mauiAppBuilder;
    }
}