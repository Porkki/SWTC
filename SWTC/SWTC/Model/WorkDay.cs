using System;
using System.Collections.Generic;
using System.Text;

namespace SWTC.Model
{
    class WorkDay : ViewModel.BaseVM
    {
        private DateTime _SelectedDate = DateTime.Today;

        public DateTime SelectedDate
        {
            get
            {
                return _SelectedDate;
            }
            set
            {
                if (value != _SelectedDate)
                {
                    _SelectedDate = value;
                    OnPropertyChanged("SelectedDate");
                }
            }
        }

        private TimeSpan _StartTime;

        public TimeSpan StartTime
        {
            get
            {
                return _StartTime;
            }
            set
            {
                if (value != _StartTime)
                {
                    _StartTime = value;
                    OnPropertyChanged("StartTime");
                }
            }
        }

        private TimeSpan _EndTime;

        public TimeSpan EndTime
        {
            get
            {
                return _EndTime;
            }

            set
            {
                if (value != _EndTime)
                {
                    _EndTime = value;
                    OnPropertyChanged("EndTime");
                }
            }
        }

        private TimeSpan _Break;

        public TimeSpan Break
        {
            get
            {
                return _Break;
            }
            set
            {
                if (value != _Break)
                {
                    _Break = value;
                    OnPropertyChanged("Break");
                }
            }
        }

        public TimeSpan TotalHours()
        {
            if (StartTime != TimeSpan.Zero || EndTime != TimeSpan.Zero)
            {
                return (EndTime - StartTime) - Break;
            }
            else
            {
                return TimeSpan.Zero;
            }
        }


    }
}
