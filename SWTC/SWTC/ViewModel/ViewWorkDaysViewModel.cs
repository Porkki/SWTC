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

        public ButtonCommand RemoveWorkDay { get; private set; }

        public ViewWorkDaysViewModel(INavigation navigation)
        {
            this.Navigation = navigation;
            this.WorkDayRepository = new WorkDayRepository();
            WorkDaysList = this.WorkDayRepository.GetAllWorkDays();

            RemoveWorkDay = new ButtonCommand(RemoveWorkDayExec, TrueCommand);
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

        public void RemoveWorkDayExec()
        {
            this.WorkDayRepository.DeleteWorkDay(SelectedItem.ID);
            //After removing selected WorkDay we need to set the WorkDaysList again to see the changes in the database
            WorkDaysList = WorkDayRepository.GetAllWorkDays();
        }

        public bool TrueCommand()
        {
            return true;
        }
    }
}
