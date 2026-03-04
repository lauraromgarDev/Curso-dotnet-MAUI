namespace WeatherClient
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        //Tenemos un metodo que va a usar un servicio.
        private async void btnRefresh_Clicked(object sender, EventArgs e)
        {
            btnRefresh.IsEnabled = false;
            actIsBusy.IsRunning = true;

            BindingContext = await Services.WeatherServer.GetWeather(txtPostalCode.Text);

            btnRefresh.IsEnabled = true;
            actIsBusy.IsRunning = false;
        }
    }
}
