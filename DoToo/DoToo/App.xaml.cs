using Microsoft.Extensions.DependencyInjection;

namespace DoToo
{
    public partial class App : Application
    {
        public App(Views.MainView view)
        {
            InitializeComponent();
            MainPage = new NavigationPage(view);
        }


    }
}