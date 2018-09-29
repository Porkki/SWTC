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

        public ViewWorkDaysViewModel(INavigation navigation)
        {
            this.Navigation = navigation;
            this.WorkDayRepository = new WorkDayRepository();
            WorkDaysList = this.WorkDayRepository.GetAllWorkDays();

            RemoveWorkDay = new Command(async () => await RemoveWorkDayExec());
        }

        private DateTime _StartDate = DateTime.Today;
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

        public async Task RemoveWorkDayExec()
        {
            if (SelectedItem != null)
            {
                this.WorkDayRepository.DeleteWorkDay(SelectedItem.ID);
                //After removing selected WorkDay we need to set the WorkDaysList again to see the changes in the database
                WorkDaysList = WorkDayRepository.GetAllWorkDays();
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
