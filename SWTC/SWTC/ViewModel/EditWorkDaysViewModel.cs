using SWTC.Model;
using SWTC.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SWTC.ViewModel
{
    class EditWorkDaysViewModel : BaseVM
    {

        public INavigation Navigation { get; set; }
        public IWorkDayRepository WorkDayRepository;

        public Command Save { get; private set; }
        public Command Cancel { get; private set; }

        public WorkDay EditDay;

        public EditWorkDaysViewModel(INavigation navigation, int id)
        {
            Navigation = navigation;
            WorkDayRepository = new WorkDayRepository();

            Save = new Command(async () => await SaveExec());
            //Cancel = new Command(async () => await CancelExec());

            EditDay = WorkDayRepository.GetWorkDay(id);
        }

        #region WorkDayVars

        public DateTime SelectedDate
        {
            get
            {
                return EditDay.SelectedDate;
            }
            set
            {
                if (value != EditDay.SelectedDate)
                {
                    EditDay.SelectedDate = value;
                    OnPropertyChanged("SelectedDate");
                }
            }
        }

        public TimeSpan StartTime
        {
            get
            {
                return EditDay.StartTime;
            }
            set
            {
                if (value != EditDay.StartTime)
                {
                    EditDay.StartTime = value;
                    OnPropertyChanged("StartTime");
                    OnPropertyChanged("TotalHours");
                }
            }
        }

        public TimeSpan EndTime
        {
            get
            {
                return EditDay.EndTime;
            }
            set
            {
                if (value != EditDay.EndTime)
                {
                    EditDay.EndTime = value;
                    OnPropertyChanged("EndTime");
                    OnPropertyChanged("TotalHours");
                }
            }
        }

        public TimeSpan Break
        {
            get
            {
                return EditDay.Break;
            }
            set
            {
                if (value != EditDay.Break)
                {
                    EditDay.Break = value;
                    OnPropertyChanged("Break");
                    OnPropertyChanged("TotalHours");
                }
            }
        }

        public string Info
        {
            get
            {
                return EditDay.Info;
            }
            set
            {
                if (value != EditDay.Info)
                {
                    EditDay.Info = value;
                }
            }
        }

        public TimeSpan Total
        {
            get
            {
                return EditDay.Total;
            }
            set
            {
                if (value != EditDay.Total)
                {
                    EditDay.Total = value;
                    OnPropertyChanged("Total");
                }
            }
        }

        public string TotalHours
        {
            get
            {
                Total = EditDay.TotalHours();
                return EditDay.TotalHours().ToString();
            }
        }

        #endregion

        public async Task SaveExec()
        {
            WorkDayRepository.UpdateWorkDay(EditDay);
            await Navigation.PopAsync();
        }

        public async Task CancelExec()
        {
            await Navigation.PopAsync();
        }
    }
}
