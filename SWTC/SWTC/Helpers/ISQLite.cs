using SQLite;

namespace SWTC.Helpers
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}
