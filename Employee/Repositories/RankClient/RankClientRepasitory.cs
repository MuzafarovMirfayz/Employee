using Employee.Constants;
using Employee.ViewModels.RankClients;
using Employee.ViewModels.RankWorker;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.ViewModels.RankClient;

public class RankClientRepasitory
{
    protected readonly NpgsqlConnection _connection;
    public RankClientRepasitory()
    {
        _connection = new NpgsqlConnection(DbConstants.DB_CONNECTIONSTRING);
    }

    public async Task<IList<RankClientsView>> GetAllAsync()
    {
        try
        {
            await _connection.OpenAsync();
            var list = new List<RankClientsView>();
            string query = $"SELECT * FROM public.rank_client;";
            await using (var command = new NpgsqlCommand(query, _connection))
            {
                await using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        var get = new RankClientsView();
                        get.name = reader.GetString(0);
                        get.sum = (int)reader.GetInt64(1);
                        get.total = (int)reader.GetInt64(2);
                        list.Add(get);
                    }
                }
            }
            return list;
        }
        catch
        {
            return new List<RankClientsView>();
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }
}
