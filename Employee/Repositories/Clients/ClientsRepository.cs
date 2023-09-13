using Employee.Constants;
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
using System.Windows.Documents;
using System.Windows.Input;

namespace Employee.Repositories.Clients;

public class ClientsRepository
{
    protected readonly NpgsqlConnection _connection;
    public ClientsRepository()
    {
        _connection = new NpgsqlConnection(DbConstants.DB_CONNECTIONSTRING);
    }



    public async Task<int> CreateAsync(Client obj)
    {
        try
        {
            await _connection.OpenAsync();

            string query = "INSERT INTO public.clients(" +
                "first_name, last_name, number, email, description, create_date, update_date) " +
                "VALUES (@first_name, @last_name, @number, @email, @description, @create_date, @update_date);";

            await using (var command = new NpgsqlCommand(query, _connection))
            {
                command.Parameters.AddWithValue("first_name", obj.first_name);
                command.Parameters.AddWithValue("last_name", obj.last_name);
                command.Parameters.AddWithValue("number", obj.number);
                command.Parameters.AddWithValue("email", obj.email);
                command.Parameters.AddWithValue("description", obj.description);
                command.Parameters.AddWithValue("create_date", obj.create_date);
                command.Parameters.AddWithValue("update_date", obj.update_date);

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



    public async Task<IList<Client>> GetAllAsync()
    {
        try
        {
            await _connection.OpenAsync();
            var list = new List<Client>();
            string query = $"select * from clients order by id;";
            await using (var command = new NpgsqlCommand(query, _connection))
            {
                await using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        var client = new Client();
                        client.id = reader.GetInt64(0);
                        client.first_name = reader.GetString(1);
                        client.last_name= reader.GetString(2);
                        client.number = reader.GetString(3);
                        client.email= reader.GetString(4);
                        client.description = reader.GetString(5);
                        client.create_date = reader.GetString(6);
                        client.update_date = reader.GetString(7);
                        list.Add(client);
                    }
                }
            }
            return list;
        }
        catch
        {
            return new List<Client>();
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
                await purchased_ProductsRepository.DeleteClientsAsync(id);
                string query = $"DELETE FROM public.clients WHERE id={id};";
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


   



    public async Task<IList<Client>> SearchAsync(string obj)
    {
        try
        {
            
            await _connection.OpenAsync();
            var list = new List<Client>();
            string query = $"select * from clients where first_name  like '%{obj}%';";
            await using (var command = new NpgsqlCommand(query, _connection))
            {
                await using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        var client = new Client();
                        client.id = reader.GetInt64(0);
                        client.first_name = reader.GetString(1);
                        client.last_name = reader.GetString(2);
                        client.number = reader.GetString(3);
                        client.email = reader.GetString(4);
                        client.description = reader.GetString(5);
                        client.create_date = reader.GetString(6);
                        client.update_date = reader.GetString(7);
                        list.Add(client);
                    }
                }
            }
            return list;
        }
        catch
        {
            return new List<Client>();
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
            await _connection.OpenAsync();
            var list = new List<Client>();
            string query = $"select * from clients where id = {a};";
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
