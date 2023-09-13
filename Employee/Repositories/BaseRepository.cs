using Employee.Constants;
using Npgsql;

namespace Employee.Repositories;

public abstract class BaseRepository
{
	protected readonly NpgsqlConnection _connection;
	public BaseRepository()
	{
		_connection = new NpgsqlConnection(DbConstants.DB_CONNECTIONSTRING);
	}
}
