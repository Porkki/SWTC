using SQLite.Net;

namespace SWTC.Helpers
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}
