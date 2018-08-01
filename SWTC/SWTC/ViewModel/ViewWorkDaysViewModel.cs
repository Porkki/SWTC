using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using SWTC.Services;
using SWTC.Model;

namespace SWTC.ViewModel
{
    class ViewWorkDaysViewModel : BaseVM
    {
        public INavigation Navigation { get; set; }
        public IWorkDayRepository WorkDayRepository;

        

        public WorkDay CurrentWorkDay;

        public ViewWorkDaysViewModel(INavigation navigation)
        {
            this.Navigation = navigation;
            this.WorkDayRepository = new WorkDayRepository();
            this.CurrentWorkDay = new WorkDay();
            WorkDaysList = this.WorkDayRepository.GetAllWorkDays();
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
    }
}
