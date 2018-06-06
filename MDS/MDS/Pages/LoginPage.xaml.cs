using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MDS
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
	{
		public LoginPage ()
		{
			InitializeComponent ();
        }

        public async void OnLoginButtonClicked(object sender, EventArgs e)
        {
            LoadingSpinner.IsRunning = true;

            var user = new User
            {
                Username = UsernameEntry.Text,
                Password = PasswordEntry.Text
            };

            var isValid = AreCredentialsCorrect(user);

            if (isValid)
            {
                App.IsUserLoggedIn = true;
                var mainPage = new MainPage(user);
                await Navigation.PushAsync(mainPage);
            }
            else
            {
                LoadingSpinner.IsRunning = false;
                PasswordEntry.Text = string.Empty;
                await DisplayAlert("Błąd", "Podane hasło jest nieprawidłowe.", "OK");
            }
        }

        private bool AreCredentialsCorrect(User user)
        {
            //var encryptedPassword = Encryptor.MD5Hash(user.Password);

            var client = new RestSharpClient();
            var response = client.Login(user);

            if (response.ApiToken != null)
            {
                user.Token = response.ApiToken;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}