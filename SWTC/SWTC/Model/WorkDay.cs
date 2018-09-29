using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace SWTC.Model
{
    [Table("WorkDay")]
    public class WorkDay
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

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
                }
            }
        }

        private string _Info;
        public string Info
        {
            get
            {
                return _Info;
            }
            set
            {
                if (value != _Info)
                {
                    _Info = value;
                }
            }
        }

        private TimeSpan _Total;
        public TimeSpan Total
        {
            get
            {
                return _Total;
            }
            set
            {
                if (value != _Total)
                {
                    _Total = value;
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
