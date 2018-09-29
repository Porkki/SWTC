using SWTC.Model;
using SWTC.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SWTC.ViewModel
{
    class WorkTimeViewModel : BaseVM
    {
        public INavigation Navigation { get; set; }
        public IWorkDayRepository workDayRepository;

        public WorkDay NewWorkDay;

        public Command AddWorkDayCommand { get; private set; }

        public WorkTimeViewModel(INavigation navigation)
        {
            this.Navigation = navigation;
            this.workDayRepository = new WorkDayRepository();

            NewWorkDay = new WorkDay();
            AddWorkDayCommand = new Command(async () => await AddWorkDay());
        }

        async Task AddWorkDay()
        {
            if (StartTime == TimeSpan.Zero || EndTime == TimeSpan.Zero)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "There is wrong value!", "Ok");
            } else
            {
                workDayRepository.InsertWorkDay(NewWorkDay);
                await Navigation.PushAsync(new MainPage());
            }
        }

        public DateTime SelectedDate
        {
            get
            {
                return NewWorkDay.SelectedDate;
            }
            set
            {
                if (value != NewWorkDay.SelectedDate)
                {
                    NewWorkDay.SelectedDate = value;
                    OnPropertyChanged("SelectedDate");
                }
            }
        }

        public TimeSpan StartTime
        {
            get
            {
                return NewWorkDay.StartTime;
            }
            set
            {
                if (value != NewWorkDay.StartTime)
                {
                    NewWorkDay.StartTime = value;
                    OnPropertyChanged("StartTime");
                    OnPropertyChanged("TotalHours");
                }
            }
        }

        public TimeSpan EndTime
        {
            get
            {
                return NewWorkDay.EndTime;
            }
            set
            {
                if (value != NewWorkDay.EndTime)
                {
                    NewWorkDay.EndTime = value;
                    OnPropertyChanged("EndTime");
                    OnPropertyChanged("TotalHours");
                }
            }
        }

        public TimeSpan Break
        {
            get
            {
                return NewWorkDay.Break;
            }
            set
            {
                if (value != NewWorkDay.Break)
                {
                    NewWorkDay.Break = value;
                    OnPropertyChanged("Break");
                    OnPropertyChanged("TotalHours");
                }
            }
        }

        public string Info
        {
            get
            {
                return NewWorkDay.Info;
            }
            set
            {
                if (value != NewWorkDay.Info)
                {
                    NewWorkDay.Info = value;
                }
            }
        }

        public TimeSpan Total
        {
            get
            {
                return NewWorkDay.Total;
            }
            set
            {
                if (value != NewWorkDay.Total)
                {
                    NewWorkDay.Total = value;
                    OnPropertyChanged("Total");
                }
            }
        }

        public string TotalHours
        {
            get
            {
                Total = NewWorkDay.TotalHours();
                return NewWorkDay.TotalHours().ToString();
            }
        }
    }
}
