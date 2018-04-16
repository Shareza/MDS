using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MDS
{
	public partial class MainPage : ContentPage
	{
        private User User;

        public MainPage() { }

        public MainPage(User user)
        {
            this.User = user;
            InitializeComponent();
            
		}
	}

}
