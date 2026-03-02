namespace Ejercicio1_Alignment
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }


        private void HorizontalStart(object sender, EventArgs e)
        {
            target.HorizontalOptions = LayoutOptions.Start;
        }
        private void HorizontalCenter(object sender, EventArgs e)
        {
            target.HorizontalOptions = LayoutOptions.Center;
        }
        private void HorizonalEnd(object sender, EventArgs e)
        {
            target.HorizontalOptions = LayoutOptions.End;
        }
        private void HorizontalFill(object sender, EventArgs e)
        {
            target.HorizontalOptions = LayoutOptions.Fill;
        }

        private void VerticalStart(Object sender, EventArgs e)
        {
            target.VerticalOptions = LayoutOptions.Start;
        }

        private void VerticalCenter(Object sender, EventArgs e)
        {
            target.VerticalOptions = LayoutOptions.Center;
        }
        private void VerticalEnd(Object sender, EventArgs e)
        {
            target.VerticalOptions = LayoutOptions.End;
        }
        private void VerticalFill(Object sender, EventArgs e)
        {
            target.VerticalOptions = LayoutOptions.Fill;
        }
    }
}
