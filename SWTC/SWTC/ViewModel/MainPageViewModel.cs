using SWTC.Model;
using SWTC.Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SWTC.ViewModel
{
    class MainPageViewModel : BaseVM
    {
        public ICommand NewWorkDay { get; private set; }
        public ICommand ViewWorkDays { get; private set; }
        public ICommand Settings { get; private set; }

        public IWorkDayRepository WorkDayRepository;
        private List<WorkDay> _WorkDayList;
        private List<WorkDay> _CurWageHoursList;

        private DateTime _StartDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);

        public INavigation Navigation { get; set; }
        /// <summary>
        /// Default Constructor
        /// </summary>
        public MainPageViewModel(INavigation navigation)
        {
            Navigation = navigation;

            WorkDayRepository = new WorkDayRepository();

            NewWorkDay = new Command(async () =>
            {
                await Application.Current.MainPage.Navigation.PushAsync(new Views.NewWorkDay());
            });
            ViewWorkDays = new Command(async () =>
            {
                await Application.Current.MainPage.Navigation.PushAsync(new Views.ViewWorkDays());
            });
            Settings = new Command(async () =>
            {
                await Application.Current.MainPage.Navigation.PushAsync(new Views.ViewSettings());
            });

            if (DateTime.Now.Day < 16)
            {
                _StartDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            }
            else
            {
                _StartDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 16);
            }

            _WorkDayList = WorkDayRepository.GetCurrentWeekWorkDays(DateTime.Today);
            _CurWageHoursList = WorkDayRepository.GetBetweenDates(_StartDate,DateTime.Now);
        }


        public string CurWeekHours
        {
            get
            {
                //_WorkDayList = WorkDayRepository.GetCurrentWeekWorkDays(DateTime.Today);
                TimeSpan total = TimeSpan.Zero;
                foreach (var WorkDay in _WorkDayList)
                {
                    total += WorkDay.Total;
                }
                double var1 = total.TotalHours;
                return Math.Round(var1, 2).ToString();
            }
        }

        public string CurWageHours
        {
            get
            {
                TimeSpan total = TimeSpan.Zero;
                foreach (var WorkDay in _CurWageHoursList)
                {
                    total += WorkDay.Total;
                }
                double var1 = total.TotalHours;
                return Math.Round(var1, 2).ToString();
            }
        }
    }
}
