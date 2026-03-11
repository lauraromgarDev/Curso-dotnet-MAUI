using News.ViewModels;

namespace News.Views;

public partial class HeadlinesView : ContentPage
{
    readonly HeadlinesViewModel viewModel;
    public HeadlinesView(HeadlinesViewModel viewModel)
    {
        this.viewModel = viewModel;
        InitializeComponent();

        Task.Run(async () => await Initialize(GetScopeFromRoute()));
    }


    /**
     * Este metodo Sirve para que la aplicación sepa exactamente en qué sección 
     * está el usuario simplemente "leyendo" la dirección (URL) de la página actual.
     */
    private string GetScopeFromRoute()
    {
        var route = Shell.Current.CurrentState.Location.OriginalString.Split("/").LastOrDefault();

        return route;
    }

    private async Task Initialize(string scope)
    {
        BindingContext = viewModel;
        await viewModel.Initialize(scope);
    }
}