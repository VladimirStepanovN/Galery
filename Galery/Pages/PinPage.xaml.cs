using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Galery.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PinPage : ContentPage
    {
        private string _pinCode;
        public PinPage()
        {
            InitializeComponent();
            _pinCode = Preferences.Get("Password", string.Empty);
            if (_pinCode == string.Empty)
            {
                HeaderLabel.Text = "Введите ПИН-код для регистрации";
            }
            else
            {
                HeaderLabel.Text = "Введите ПИН - код для входа";
            }
        }

        private void WelcomeMethod(object sender, EventArgs e)
        {
            string enterPwd = Password.Text;
            if (_pinCode == string.Empty)
            {
                Preferences.Set("Password", enterPwd);

            }
            else
            {
                if (_pinCode != Password.Text)
                {
                    WarningMessageLabel.TextColor = Color.Red;
                    WarningMessageLabel.Text = "Неверный ПИН-код";
                    return;
                }
            }
            Navigation.PushAsync(new GaleryPage());
        }

        private void PasswordChanging(object sender, TextChangedEventArgs e)
        {
            if (Password.Text.Length != 4)
            {
                WarningMessageLabel.TextColor = Color.LightBlue;
                WarningMessageLabel.Text = "Введите 4-значный ПИН-код";
                EnterButton.IsEnabled = false;
            }
            else
            {
                EnterButton.IsEnabled = true;
                WarningMessageLabel.Text = string.Empty;
            }
        }
    }
}