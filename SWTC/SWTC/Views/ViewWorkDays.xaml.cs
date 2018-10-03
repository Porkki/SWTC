using SWTC.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SWTC.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ViewWorkDays : ContentPage
	{
		public ViewWorkDays()
		{
			InitializeComponent();
            BindingContext = new ViewWorkDaysViewModel(Navigation);
		}
	}
}