using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SWTC.ViewModel
{
    class ViewWorkDaysViewModel : BaseVM
    {
        public INavigation Navigation { get; set; }
        public ViewWorkDaysViewModel(INavigation navigation)
        {
            this.Navigation = navigation;
        }
    }
}
