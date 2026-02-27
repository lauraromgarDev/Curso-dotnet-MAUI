namespace NotasVisita
{
    public partial class MainPage : ContentPage
    {
        string _filename = Path.Combine(FileSystem.AppDataDirectory, "notas.txt");
        public MainPage()
        {
            InitializeComponent();
            editor.Text = File.Exists(_filename) ? File.ReadAllText(_filename) : string.Empty;
        }


        private async void Button_Clicked(object sender, EventArgs e)
        {
            File.WriteAllText(_filename, editor.Text);
        }

        private void btnBorrar_Clicked(object sender, EventArgs e)
        {
            if (File.Exists(_filename))
            {
                File.Delete(_filename);
            }
            editor.Text = string.Empty;
        }
    }
}
