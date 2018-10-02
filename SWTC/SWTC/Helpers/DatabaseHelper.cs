using SQLite;
using SWTC.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace SWTC.Helpers
{
    public class DatabaseHelper
    {
        static SQLiteConnection sqliteconnection;
        public const string DbFileName = "WorkDays.db";

        public DatabaseHelper()
        {
            sqliteconnection = DependencyService.Get<ISQLite>().GetConnection();
            sqliteconnection.CreateTable<WorkDay>();
        }

        public List<WorkDay> GetAllWorkDays()
        {
            return (from data in sqliteconnection.Table<WorkDay>()
                    select data).ToList();
        }

        public List<WorkDay> GetBetweenDates(DateTime start, DateTime end)
        {
            string sqlstart = DateTimeSQLite(start);
            string sqlend = DateTimeSQLite(end);

            string query = string.Format("SELECT * FROM WorkDay WHERE SelectedDate BETWEEN '{0}' AND '{1}' ORDER BY SelectedDate", sqlstart, sqlend);

            return sqliteconnection.Query<WorkDay>(query);
        }

        private string DateTimeSQLite(DateTime datetime)
        {
            return datetime.ToString("yyyy-MM-dd");
        }

        public WorkDay GetWorkDay(int id)
        {
            return sqliteconnection.Table<WorkDay>().FirstOrDefault(t => t.ID == id);
        }

        public void DeleteWorkDay(int id)
        {
            sqliteconnection.Delete<WorkDay>(id);
        }

        public void InsertWorkDay(WorkDay workday)
        {
            sqliteconnection.Insert(workday);
        }

        public void UpdateWorkDay(WorkDay workday)
        {
            sqliteconnection.Update(workday);
        }
    }
}
