using Employee.Constants;
using Employee.Entities.Workers;
using Employee.ViewModels.WorkerSalary;
using Npgsql;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace Employee.Repositories.Salary;

public class WorkerSalaryRepasitory
{
    protected readonly NpgsqlConnection _connection;

    public WorkerSalaryRepasitory()
    {
        _connection = new NpgsqlConnection(DbConstants.DB_CONNECTIONSTRING);
    }

    public async Task<IList<WorkerSalaryViewModel>> GetAllAsync()
    {
        try
        {
            await _connection.OpenAsync();
            var list = new List<WorkerSalaryViewModel>();
            string query = $"SELECT * FROM public.worker_salary;";
            await using (var command = new NpgsqlCommand(query, _connection))
            {
                await using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        var get = new WorkerSalaryViewModel();
                        get.name = reader.GetString(0);
                        get.sum =(int)reader.GetInt64(1);
                        get.image = reader.GetString(2);
                        list.Add(get);
                    }
                }
            }
            return list;
        }
        catch
        {
            return new List<WorkerSalaryViewModel>();
        }
        finally
        {
            await _connection.CloseAsync();
        }

    }


    public async Task<IList<WorkerSalaryViewModel>> SearchAsync(string name)
    {
        try
        {
            await _connection.OpenAsync();
            var list = new List<WorkerSalaryViewModel>();
            string query = $"SELECT * FROM public.worker_salary;";
            await using (var command = new NpgsqlCommand(query, _connection))
            {
                await using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        if(reader.GetString(0) == name)
                        {
                            var get = new WorkerSalaryViewModel();
                            get.name = reader.GetString(0);
                            get.sum = (int)reader.GetInt64(1);
                            get.image = reader.GetString(2);
                            list.Add(get);
                        }
                        
                    }
                }
            }
            return list;
        }
        catch
        {
            return new List<WorkerSalaryViewModel>();
        }
        finally
        {
            await _connection.CloseAsync();
        }

    }






}
