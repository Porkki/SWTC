using SWTC.Model;
using SWTC.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SWTC.ViewModel
{
    class WorkTimeViewModel : BaseVM
    {
        public INavigation Navigation { get; set; }

        public WorkDay NewWorkDay;

        public ButtonCommand AddWorkDay { get; private set; }

        public WorkTimeViewModel(INavigation navigation)
        {
            this.Navigation = navigation;

            NewWorkDay = new WorkDay();
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
                    OnPropertyChanged("StartTime");
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

        public string TotalHours
        {
            get
            {
                return NewWorkDay.TotalHours().ToString();
            }
        }
    }
}
