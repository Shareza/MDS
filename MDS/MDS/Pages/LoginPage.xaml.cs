using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using RestSharp.Deserializers;

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
            var user = new User
            {
                Username = UsernameEntry.Text,
                Password = PasswordEntry.Text
            };

            var isValid = AreCredentialsCorrect(user);

            if (isValid)
            {
                App.IsUserLoggedIn = true;
                //Navigation.InsertPageBefore(new MainPage(), this);
                //await Navigation.PopAsync();
                var mainPage = new MainPage(user);
                //mainPage.BindingContext = user;
                await Navigation.PushAsync(mainPage);
            }
            else
            {
                PasswordEntry.Text = string.Empty;
                await DisplayAlert("Błąd", "Podane hasło jest nieprawidłowe.", "OK");
            }
        }

        private bool AreCredentialsCorrect(User user)
        {
            //var encryptedPassword = Encryptor.MD5Hash(user.Password);


            var client = new RestClient("http://mds.kopnet.pl");
                client.AddHandler("*", new JsonDeserializer());

            var request = new RestRequest("/logIn", Method.POST);
                request.AddParameter("inputEmailPhone", user.Username);
                request.AddParameter("inputPassword", user.Password);



            var response = client.Execute<LoginResponse>(request);

            if (response.Data.ApiToken != null)
            {
                user.Token = response.Data.ApiToken;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}