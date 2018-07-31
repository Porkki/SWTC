using SWTC.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SWTC.Services
{
    public interface IWorkDayRepository
    {
        List<WorkDay> GetAllWorkDays();

        WorkDay GetWorkDay(int id);

        void DeleteWorkDay(int id);

        void InsertWorkDay(WorkDay workday);

        void UpdateWorkDay(WorkDay workday);
    }
}
