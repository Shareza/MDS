using MDS.Config;
using MDS.Helpers;
using MDS.Models;
using MDS.Pages;
using Plugin.Toasts;
using System;
using Xamarin.Forms;


namespace MDS
{
	public partial class MainPage : ContentPage
	{
        private User User;
        private EventsResponse scheduleData;
        private int eventsCount;

        public MainPage() { }

        public MainPage(User user)
        {
            NavigationPage.SetHasBackButton(this, false);

            this.User = user;
            scheduleData = GetEvents();

            InitializeComponent();
            InitializeInterface();
            Toast();

            Title = InterfaceConfig.MainPageTitle;
        }

        private void Toast()
        {
            var notificator = DependencyService.Get<IToastNotificator>();

            if(scheduleData != null)
                notificator.Notify(ToastNotificationType.Success, "Sukces", $"Pobrano {eventsCount} zdarzenia", TimeSpan.FromSeconds(2));
            else
                notificator.Notify(ToastNotificationType.Error, "Error", "Nie udało się pobrać danych.", TimeSpan.FromSeconds(2));
        }

        public EventsResponse OnGetEventsBtnClicked(object sender, EventArgs e)
        {
            var client = new RestSharpClient();
            var schedule = client.GetEventsByCount(User.Token);

            return schedule;
        }

        public EventsResponse GetEvents()
        {
            var client = new RestSharpClient();
            var schedule = client.GetEventsByCount(User.Token);

            return schedule;
        }

        public void InitializeInterface()
        {
            var layout = new StackLayout() { Spacing = 0 };

            for (int i = 0; i < scheduleData.schedule.Count; i++)
            {
                var dayLabel = new Label
                {
                    Text = scheduleData.schedule[i].Day.Date.ToShortDateString(),
                    //fix date so it shows: 7 Maj - Czwartek

                    HorizontalOptions = LayoutOptions.Start,
                    WidthRequest = InterfaceConfig.DayLabelWidth,
                    TextColor = Color.Black
                };
                layout.Children.Add(dayLabel);

                for (int j = 0; j < scheduleData.schedule[i].Events.Count; j++)
                {
                    eventsCount++;
                    var button = new Button
                    {

                        Text = EventsMapper.GetName(scheduleData.schedule[i].Events[j].EventType) +
                               "\n" +
                               scheduleData.schedule[i].Events[j].EventStartTime + " - " +
                               scheduleData.schedule[i].Events[j].EventEndTime,
                        //use string bilder?

                        HorizontalOptions = LayoutOptions.End,
                        HeightRequest = InterfaceConfig.EventButtonHeight,
                        WidthRequest = InterfaceConfig.EventButtonWidth,
                        BackgroundColor = Color.FromHex(InterfaceConfig.DomainColorHex),
                        TextColor = Color.White,
                };
                    var temp = scheduleData.schedule[i].Events[j];

                    button.Clicked += async delegate 
                    {
                        await Navigation.PushAsync(new EventDetailsPage(temp));
                    };
                    layout.Children.Add(button);
                }
            }

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
        }
    }

}
