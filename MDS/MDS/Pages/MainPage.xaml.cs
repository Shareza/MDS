using MDS.Models;
using System;
using Xamarin.Forms;


namespace MDS
{
	public partial class MainPage : ContentPage
	{
        private User User;
        //private EventsResponse scheduleData;

        public MainPage() { }

        public MainPage(User user)
        {
            this.User = user;
            InitializeComponent();


            NavigationPage.SetHasBackButton(this, false);




            var layout = new StackLayout() { Spacing = 0};


            var label = new Label
            {
                Text = "  15 \n  pon",
                HorizontalOptions = LayoutOptions.Start,
                WidthRequest = 100,
                TextColor = Color.Black
            };


            var button = new Button
            {
                Text = "Strzyżenie męskie\n 8:00 - 8:30",
                HorizontalOptions = LayoutOptions.End,
                HeightRequest = 60,
                WidthRequest = 210,
                BackgroundColor = Color.FromHex("#121F28"),
                TextColor = Color.LightSlateGray,

            };

            var button1 = new Button
            {
                Text = "Strzyżenie męskie\n 9:00 - 9:30",
                HorizontalOptions = LayoutOptions.End,
                HeightRequest = 60,
                WidthRequest = 210,
                BackgroundColor = Color.FromHex("#121F28"),
                TextColor = Color.Gray
            };

            var button2 = new Button
            {
                Text = "Strzyżenie męskie\n 10:00 - 10:30",
                HorizontalOptions = LayoutOptions.End,
                HeightRequest = 60,
                WidthRequest = 210,
                BackgroundColor = Color.FromHex("#121F28"),
                TextColor = Color.SlateGray
            };

            var label1 = new Label
            {
                Text = "  16 \n  wto",
                HorizontalOptions = LayoutOptions.Start,
                WidthRequest = 210,
                TextColor = Color.Black
            };


            var button3 = new Button
            {
                Text = "Strzyżenie męskie\n 8:00 - 8:30",
                HorizontalOptions = LayoutOptions.End,
                HeightRequest = 60,
                WidthRequest = 210,
                BackgroundColor = Color.FromHex("#121F28"),
                TextColor = Color.White
            };

            var button4 = new Button
            {
                Text = "Strzyżenie męskie\n 9:00 - 9:30",
                HorizontalOptions = LayoutOptions.End,
                HeightRequest = 60,
                WidthRequest = 210,
                BackgroundColor = Color.FromHex("#121F28"),
                TextColor = Color.White
            };

            var button5 = new Button
            {
                Text = "Strzyżenie męskie\n 10:00 - 10:30",
                HorizontalOptions = LayoutOptions.End,
                HeightRequest = 60,
                WidthRequest = 210,
                BackgroundColor = Color.FromHex("#121F28"),
                TextColor = Color.White
            };

            var label2 = new Label
            {
                Text = "  18 \n  śro",
                HorizontalOptions = LayoutOptions.Start,
                WidthRequest = 100,
                TextColor = Color.Black
            };


            var button6 = new Button
            {
                Text = "Strzyżenie męskie\n 8:00 - 8:30",
                HorizontalOptions = LayoutOptions.End,
                HeightRequest = 60,
                WidthRequest = 210,
                BackgroundColor = Color.FromHex("#121F28"),
                TextColor = Color.LightSlateGray,

            };

            var button7 = new Button
            {
                Text = "Strzyżenie męskie\n 9:00 - 9:30",
                HorizontalOptions = LayoutOptions.End,
                HeightRequest = 60,
                WidthRequest = 210,
                BackgroundColor = Color.FromHex("#121F28"),
                TextColor = Color.Gray
            };

            var button8 = new Button
            {
                Text = "Strzyżenie męskie\n 10:00 - 10:30",
                HorizontalOptions = LayoutOptions.End,
                HeightRequest = 60,
                WidthRequest = 210,
                BackgroundColor = Color.FromHex("#121F28"),
                TextColor = Color.SlateGray
            };

            var label3 = new Label
            {
                Text = "  19 \n  czw",
                HorizontalOptions = LayoutOptions.Start,
                WidthRequest = 210,
                TextColor = Color.Black
            };


            var button9 = new Button
            {
                Text = "Strzyżenie męskie\n 8:00 - 8:30",
                HorizontalOptions = LayoutOptions.End,
                HeightRequest = 60,
                WidthRequest = 210,
                BackgroundColor = Color.FromHex("#121F28"),
                TextColor = Color.White
            };

            var button10 = new Button
            {
                Text = "Strzyżenie męskie\n 9:00 - 9:30",
                HorizontalOptions = LayoutOptions.End,
                HeightRequest = 60,
                WidthRequest = 210,
                BackgroundColor = Color.FromHex("#121F28"),
                TextColor = Color.White
            };

            var button11 = new Button
            {
                Text = "Strzyżenie męskie\n 10:00 - 10:30",
                HorizontalOptions = LayoutOptions.End,
                HeightRequest = 60,
                WidthRequest = 210,
                BackgroundColor = Color.FromHex("#121F28"),
                TextColor = Color.White
            };

            layout.Children.Add(label);
            layout.Children.Add(button);
            layout.Children.Add(button1);
            layout.Children.Add(button2);


            layout.Children.Add(label1);
            layout.Children.Add(button3);
            layout.Children.Add(button4);
            layout.Children.Add(button5);
            layout.Children.Add(label2);
            layout.Children.Add(button6);
            layout.Children.Add(button7);
            layout.Children.Add(button8);
            layout.Children.Add(label3);
            layout.Children.Add(button9);
            layout.Children.Add(button10);
            layout.Children.Add(button11);


            ScrollView clientscroll = new ScrollView
            {
                Padding = new Thickness(0, 10, 15, 10),
                HeightRequest = 50,
                WidthRequest = 50,
                Orientation = ScrollOrientation.Vertical,
                VerticalOptions = LayoutOptions.Fill,
                HorizontalOptions = LayoutOptions.Fill,
                // ContentSize = new Size(50,50),
                Content = new StackLayout
                {
                    Orientation = StackOrientation.Vertical,
                    Children = { layout }

                }
            };



            Content = clientscroll;

            Title = "            MDS - Grafik";

        }

        public EventsResponse OnGetEventsBtnClicked(object sender, EventArgs e)
        {
            var client = new RestSharpClient();
            var schedule = client.GetEventsByCount(User.Token);

            return schedule;
        }
    }

}
