using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SWTC
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();

            BindingContext = new ViewModel.MainPageViewModel(Navigation);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            //Dirty way to update CurWeekHours after popasync from another page
            BindingContext = new ViewModel.MainPageViewModel(Navigation);
        }
    }
}
