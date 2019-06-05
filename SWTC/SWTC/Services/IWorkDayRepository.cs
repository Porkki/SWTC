using SWTC.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SWTC.Services
{
    public interface IWorkDayRepository
    {
        List<WorkDay> GetAllWorkDays();

        List<WorkDay> GetBetweenDates(DateTime start, DateTime end);

        List<WorkDay> GetCurrentWeekWorkDays(DateTime dateTime);

        WorkDay GetWorkDay(int id);

        void DeleteWorkDay(int id);

        void InsertWorkDay(WorkDay workday);

        void UpdateWorkDay(WorkDay workday);
    }
}
