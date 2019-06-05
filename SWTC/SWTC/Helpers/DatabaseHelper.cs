using SQLite;
using SWTC.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
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

            string query = string.Format("SELECT * FROM WorkDay WHERE SelectedDate BETWEEN '{0}' AND '{1}T23:59:59.000' ORDER BY SelectedDate", sqlstart, sqlend);

            return sqliteconnection.Query<WorkDay>(query);
        }

        public List<WorkDay> GetCurrentWeekWorkDays(DateTime dateTime)
        {
            DateTime start = FirstDateOfWeek(dateTime.Year, GetWeekNumber(dateTime), CultureInfo.CurrentCulture);
            DateTime end = FirstDateOfWeek(dateTime.Year, GetWeekNumber(dateTime), CultureInfo.CurrentCulture).AddDays(6);

            string sqlstart = DateTimeSQLite(start);
            string sqlend = DateTimeSQLite(end);

            string query = string.Format("SELECT * FROM WorkDay WHERE SelectedDate BETWEEN '{0}' AND '{1}T23:59:59.000' ORDER BY SelectedDate", sqlstart, sqlend);

            return sqliteconnection.Query<WorkDay>(query);
        }

        private static int GetWeekNumber(DateTime time)
        {
            DayOfWeek day = CultureInfo.InvariantCulture.Calendar.GetDayOfWeek(time);
            if (day >= DayOfWeek.Monday && day <= DayOfWeek.Wednesday)
            {
                time = time.AddDays(3);
            }
            return CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(time, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
        }

        private static DateTime FirstDateOfWeek(int year, int weeknumber, CultureInfo ci)
        {
            DateTime jan1 = new DateTime(year, 1, 1);
            int daysOffset = ci.DateTimeFormat.FirstDayOfWeek - jan1.DayOfWeek;
            DateTime firstWeekDay = jan1.AddDays(daysOffset);
            int firstWeek = ci.Calendar.GetWeekOfYear(jan1, ci.DateTimeFormat.CalendarWeekRule, ci.DateTimeFormat.FirstDayOfWeek);
            if ((firstWeek <= 1 || firstWeek >= 52) && daysOffset >= -3)
            {
                weeknumber -= 1;
            }
            return firstWeekDay.AddDays(weeknumber * 7);
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
