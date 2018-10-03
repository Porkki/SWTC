using SWTC.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SWTC.ViewModel
{
    class SettingsViewModel : BaseVM
    {
        public INavigation Navigation { get; set; }
        public IWorkDayRepository workDayRepository;

        public SettingsViewModel(INavigation navigation)
        {
            Navigation = navigation;
        }
    }
}
