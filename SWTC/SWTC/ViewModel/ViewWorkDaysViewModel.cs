using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using SWTC.Services;
using SWTC.Model;
using System.Threading.Tasks;

namespace SWTC.ViewModel
{
    class ViewWorkDaysViewModel : BaseVM
    {
        public INavigation Navigation { get; set; }
        public IWorkDayRepository WorkDayRepository;

        public Command RemoveWorkDay { get; private set; }
        public Command Search { get; private set; }

        public ViewWorkDaysViewModel(INavigation navigation)
        {
            Navigation = navigation;
            WorkDayRepository = new WorkDayRepository();
            

            RemoveWorkDay = new Command(async () => await RemoveWorkDayExec());
            Search = new Command(async () => await SearchExec());

            /*
             * Setting StartDate either 1st day or 15th day of the month depending what day it is
             */ 

            if (DateTime.Now.Day < 16)
            {
                StartDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            } else
            {
                StartDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 16);
            }

            WorkDaysList = WorkDayRepository.GetBetweenDates(StartDate, EndDate);

        }
        private DateTime _StartDate;

        public DateTime StartDate
        {
            get
            {
                return _StartDate;
            }
            set
            {
                if (value != _StartDate)
                {
                    _StartDate = value;
                    OnPropertyChanged("StartDate");
                }
            }
        }
        private DateTime _EndDate = DateTime.Today;
        public DateTime EndDate
        {
            get
            {
                return _EndDate;
            }
            set
            {
                if (value != _EndDate)
                {
                    _EndDate = value;
                    OnPropertyChanged("EndDate");
                }
            }
        }

        public string TotalHours
        {
            get
            {
                TimeSpan total = TimeSpan.Zero;
                foreach (var WorkDay in WorkDaysList)
                {
                    total += WorkDay.Total;
                }
                double var1 = total.TotalHours;
                return Math.Round(var1, 2).ToString();
            }
        }

        private List<WorkDay> _WorkDaysList;
        public List<WorkDay> WorkDaysList
        {
            get
            {
                return _WorkDaysList;
            }
            set
            {
                if (value != _WorkDaysList)
                {
                    _WorkDaysList = value;
                    OnPropertyChanged("WorkDaysList");
                }
            }
        }

        private WorkDay _SelectedItem;
        public WorkDay SelectedItem
        {
            get
            {
                return _SelectedItem;
            }
            set
            {
                if (value != _SelectedItem)
                {
                    _SelectedItem = value;
                    OnPropertyChanged("SelectedItem");
                }
            }
        }
        //TODO: Mahdollinen bugi, haku näyttää yhden päivän liianvähän emuloinnissa, kolmas päivä näyttää vain toisen päivän
        public async Task SearchExec()
        {
            if (StartDate > EndDate)
            {
                await Application.Current.MainPage.DisplayAlert("Virhe!", "Aloituspvm ei voi olla suurempi kuin lopetuspvm!", "Ok");
            } else
            {
                WorkDaysList = WorkDayRepository.GetBetweenDates(StartDate, EndDate);
                if (WorkDaysList.Count == 0)
                {
                    await Application.Current.MainPage.DisplayAlert("Info", "Annetuilla päivämäärillä ei löytynyt yhtään työpäivää!", "Ok");
                    OnPropertyChanged("TotalHours");
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Info", "Haku valmis!", "Ok");
                    OnPropertyChanged("TotalHours");
                }
            }
        }

        public async Task RemoveWorkDayExec()
        {
            if (SelectedItem != null)
            {
                this.WorkDayRepository.DeleteWorkDay(SelectedItem.ID);
                //After removing selected WorkDay we need to set the WorkDaysList again to see the changes in the database
                WorkDaysList = WorkDayRepository.GetBetweenDates(StartDate, EndDate);
            } else
            {
                await Application.Current.MainPage.DisplayAlert("Error", "There is no workday selected!", "Ok");
            }
            
        }

        public bool TrueCommand()
        {
            return true;
        }
    }
}
