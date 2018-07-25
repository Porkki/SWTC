using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SWTC.ViewModel
{
    class MainPageViewModel : BaseVM
    {
        public ICommand NewWorkDay { get; private set; }

        public INavigation Navigation { get; set; }
        /// <summary>
        /// Default Constructor
        /// </summary>
        public MainPageViewModel(INavigation navigation)
        {
            this.Navigation = navigation;
            NewWorkDay = new Command(async () =>
            {
                await Application.Current.MainPage.Navigation.PushAsync(new Views.NewWorkDay());
            });
        }
        private string _CurWeekHours;
        public string CurWeekHours
        {
            get
            {
                return _CurWeekHours;
            }
            set
            {
                if (value != _CurWeekHours)
                {
                    _CurWeekHours = value;
                    OnPropertyChanged("CurWeekHours");
                }
            }
        }

        #region Command Functions
        public void NewWorkDayExe()
        {
            this.CurWeekHours = "EsaPetteri 23";
        }
        public bool NewWorkDayIsValid()
        {
            return true;
        }
        #endregion
    }
}
