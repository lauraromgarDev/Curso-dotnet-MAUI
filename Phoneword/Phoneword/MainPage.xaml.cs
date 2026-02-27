namespace Phoneword
{
    public partial class MainPage : ContentPage
    {
        string? translatedNumber;

        public MainPage()
        {
            InitializeComponent();

        }

        /**
         * 
         * Este método se ejecuta cuando el usuario hace clic en el botón "Translate". 
         * Toma la cadena ingresado¡a por el usuario, lo traduce utilizando el método ToNumber de la clase PhonewordTranslator, 
         * y luego actualiza la interfaz de usuario para mostrar el número traducido. 
         * Si la traducción es exitosa, habilita el botón "Call" y cambia su texto para mostrar el número traducido. 
         * Si la traducción falla (es decir, si el número traducido es null o vacío), deshabilita el botón "Call" y restablece su texto a "Call".
         */
        private void TranslateButton_Clicked(object sender, EventArgs e)
        {
            string enteredNumber = PhoneNumberText.Text;
            translatedNumber = PhonewordTranslator.ToNumber(enteredNumber);

            if (!string.IsNullOrEmpty(translatedNumber))
            {
                CallButton.IsEnabled = true;
                CallButton.Text = "Call " + translatedNumber;
            }
            else
            {
                CallButton.IsEnabled = false;
                CallButton.Text = "Call";
            }
        }

        /**
         * Este método se ejecuta cuando el usuario hace clic en el botón "Call". 
         * Primero, muestra una alerta para confirmar si el usuario desea llamar al número traducido. 
         * Si el usuario confirma, intenta abrir la aplicación de marcación telefónica con el número traducido. 
         * Si el número no es válido o si ocurre un error al intentar abrir la aplicación de marcación, muestra una alerta indicando que no se pudo realizar la llamada.
         */

        async void CallButton_Clicked(object sender, EventArgs e)
        {
            if (await this.DisplayAlertAsync(
                "Dial a Number",
                "Would you like to call " + translatedNumber + "?",
                "Yes",
                "No"))
            {
                try
                {
                    if (PhoneDialer.Default.IsSupported && !string.IsNullOrWhiteSpace(translatedNumber))
                        PhoneDialer.Default.Open(translatedNumber);
                }
                catch (ArgumentNullException)
                {
                    await DisplayAlertAsync("Unable to dial", "Phone number was not valid.", "OK");
                }
                catch (Exception)
                {
                    // Other error has occurred.
                    await DisplayAlertAsync("Unable to dial", "Phone dialing failed.", "OK");
                }
            }
        }
    }
}
