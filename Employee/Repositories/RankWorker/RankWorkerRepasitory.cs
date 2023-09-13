using Employee.Constants;
using Employee.ViewModels.RankWorker;
using Employee.ViewModels.WorkerSalary;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Repositories.RankWorker;

public class RankWorkerRepasitory
{
    protected readonly NpgsqlConnection _connection;
    public RankWorkerRepasitory()
    {
        _connection = new NpgsqlConnection(DbConstants.DB_CONNECTIONSTRING);
    }

    public async Task<IList<RankWorkerViewModel>> GetAllAsync()
    {
        try
        {
            await _connection.OpenAsync();
            var list = new List<RankWorkerViewModel>();
            string query = $"SELECT * FROM public.rank_worker;";
            await using (var command = new NpgsqlCommand(query, _connection))
            {
                await using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        var get = new RankWorkerViewModel();
                        get.name = reader.GetString(0);
                        get.sum = (int)reader.GetInt64(1);
                        get.total = (int)reader.GetInt64(2);
                        get.image = reader.GetString(3);
                        list.Add(get);
                    }
                }
            }
            return list;
        }
        catch
        {
            return new List<RankWorkerViewModel>();
        }
        finally
        {
            await _connection.CloseAsync();
        }

    }




}
