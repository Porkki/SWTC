using System;
using System.Collections.Generic;
using System.Text;
using SWTC.Helpers;
using SWTC.Model;

namespace SWTC.Services
{
    class WorkDayRepository : IWorkDayRepository
    {
        DatabaseHelper _databasehelper;

        public WorkDayRepository()
        {
            _databasehelper = new DatabaseHelper();
        }

        public void DeleteWorkDay(int id)
        {
            _databasehelper.DeleteWorkDay(id);
        }

        public List<WorkDay> GetAllWorkDays()
        {
            return _databasehelper.GetAllWorkDays();
        }

        public List<WorkDay> GetBetweenDates(DateTime start, DateTime end)
        {
            return null;
        }

        public WorkDay GetWorkDay(int id)
        {
            return _databasehelper.GetWorkDay(id);
        }

        public void InsertWorkDay(WorkDay workday)
        {
            _databasehelper.InsertWorkDay(workday);
        }

        public void UpdateWorkDay(WorkDay workday)
        {
            _databasehelper.UpdateWorkDay(workday);
        }
    }
}
