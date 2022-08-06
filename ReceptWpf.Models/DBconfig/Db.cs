using Microsoft.Data.Sqlite;

namespace Models.DBconfig;

public abstract class Db
{
    protected readonly string? connstring = "Data Source=Database.db;";
    protected SqliteConnection _db;
    protected Db()
    {
        _db = new SqliteConnection(connstring);
    }
}