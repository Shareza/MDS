using MDS.Helpers;
using Plugin.Messaging;
using Plugin.Toasts;
using System;
using Xamarin.Forms;

namespace MDS.Pages
{
	public partial class EventDetailsPage : ContentPage
	{
        private Event Event;

		public EventDetailsPage (Event data)
		{
            this.Event = data;
			InitializeComponent ();
            InitializeInterface();
            Title = EventsMapper.GetName(Event.EventType);
        }

        private void InitializeInterface()
        {
            UserId.Text = "ID: " + Event.EventId;
            UserLabel.Text = Event.Customer.Name + " " + Event.Customer.LastName;
            EventTimeSpanLabel.Text = Event.EventStartTime.ToString() + " - " + Event.EventEndTime.ToString();
            EmailLabel.Text = Event.Customer.Email;
            PhoneNumberLabel.Text = Event.Customer.PhoneNumber;
        }

        public void OnCallImageTapped(object sender, EventArgs e)
        {
            var customer = Event.Customer.Name + " " + Event.Customer.LastName;
            var notificator = DependencyService.Get<IToastNotificator>();
            var phoneDialer = CrossMessaging.Current.PhoneDialer;

            if (phoneDialer.CanMakePhoneCall)
            {
                notificator.Notify(ToastNotificationType.Success, "Dzwonię do..", customer, TimeSpan.FromSeconds(1));
                phoneDialer.MakePhoneCall(Event.Customer.PhoneNumber);
            }
            else
                notificator.Notify(ToastNotificationType.Error, "Error", "Coś poszło nie tak..", TimeSpan.FromSeconds(1));
        }

        public void OnTextImageTapped(object sender, EventArgs e)
        {
            var messenger = CrossMessaging.Current.SmsMessenger;
            if (messenger.CanSendSms)
                messenger.SendSms(Event.Customer.PhoneNumber);
        }
    }
}