using Employee.Constants;
using Employee.Entities;
using Employee.Entities.Clients;
using Employee.Entities.Workers;
using Employee.FileJson;
using Employee.Repositories.Purchased_products;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Ink;

namespace Employee.Repositories.Workers;

public class WorkersRepository
{
    protected readonly NpgsqlConnection _connection;
    public WorkersRepository()
    {
        _connection = new NpgsqlConnection(DbConstants.DB_CONNECTIONSTRING);
    }



    public async Task<int> CreateAsync(Worker obj)
    {
        try
        {
            await _connection.OpenAsync();

            string query = "INSERT INTO public.workers(first_name, last_name, number, passport_seria, description, create_date, update_date, image)" +
                "VALUES (@first_name, @last_name, @number, @passport_seria, @description, @create_date, @update_date, @image);";
            await using (var command = new NpgsqlCommand(query, _connection))
            {
                command.Parameters.AddWithValue("first_name", obj.first_name);
                command.Parameters.AddWithValue("last_name", obj.last_name);
                command.Parameters.AddWithValue("number", obj.number);
                command.Parameters.AddWithValue("passport_seria", obj.passport_seria);
                command.Parameters.AddWithValue("description", obj.description);
                command.Parameters.AddWithValue("create_date", obj.create_date);
                command.Parameters.AddWithValue("update_date", obj.update_date);
                command.Parameters.AddWithValue("image", obj.image);

                var dbResult = await command.ExecuteNonQueryAsync();
                return dbResult;
            }
        }
        catch
        {
            return 0;
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }



    public async Task<IList<Worker>> GetAllAsync()
    {
        try
        {
            await _connection.OpenAsync();
            var list = new List<Worker>();
            string query = $"select * from workers order by id "; 
            await using (var command = new NpgsqlCommand(query, _connection))
            {
                await using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        var worker = new Worker();
                        worker.id = reader.GetInt64(0);
                        worker.first_name = reader.GetString(1);
                        worker.last_name = reader.GetString(2);
                        worker.number = reader.GetString(3);
                        worker.passport_seria = reader.GetString(4);
                        worker.description = reader.GetString(5);
                        worker.create_date = reader.GetString(6);
                        worker.update_date = reader.GetString(7);
                        worker.image = reader.GetString(8);
                        list.Add(worker);
                    }
                }
            }
            return list;
        }
        catch
        {
            return new List<Worker>();
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }



    public async Task<int> DeleteAsync(int id)
    {
        try
        {
            await _connection.OpenAsync();
            Purchased_productsRepository purchased_ProductsRepository = new Purchased_productsRepository();
                await purchased_ProductsRepository.DeleteWorkessAsync(id);    
                string query = $"DELETE FROM public.workers WHERE id={id};";
                await using (var command = new NpgsqlCommand(query, _connection))
                {
                    var result = await command.ExecuteNonQueryAsync();
                }
            return 1;
        }
        catch
        {
            return 0;
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }



    public async Task<IList<Worker>> SearchAsync(string obj)
    {
        try
        {
            await _connection.OpenAsync();
            var list = new List<Worker>();
            string query = $"select * from workers where first_name  like '%{obj}%';";
            await using (var command = new NpgsqlCommand(query, _connection))
            {
                await using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        var worker = new Worker();
                        worker.id = reader.GetInt64(0);
                        worker.first_name = reader.GetString(1);
                        worker.last_name = reader.GetString(2);
                        worker.number = reader.GetString(3);
                        worker.passport_seria = reader.GetString(4);
                        worker.description = reader.GetString(5);
                        worker.create_date = reader.GetString(6);
                        worker.update_date = reader.GetString(7);
                        worker.image = reader.GetString(8);
                        list.Add(worker);
                    }
                }
            }
            return list;
        }
        catch
        {
            return new List<Worker>();
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }



    public async Task<string> Get(int a)
    {
        try
        {
            string qayt = string.Empty;
            string qayt2 = string.Empty;

            await _connection.OpenAsync();
            string query = $"select * from workers where id = {a};";
            await using (var command = new NpgsqlCommand(query, _connection))
            {
                await using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        qayt = reader.GetString(1);
                    }
                }
            }
            return qayt;
        }
        catch
        {
            return string.Empty;
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }


     

}
