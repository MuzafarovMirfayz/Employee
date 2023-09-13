using Employee.Constants;
using Employee.Entities.Products;
using Employee.Entities.Purchased_products;
using Employee.Entities.Workers;
using Employee.FileJson;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Repositories.Purchased_products;

public class Purchased_productsRepository
{
    protected readonly NpgsqlConnection _connection;
    public Purchased_productsRepository()
    {
        _connection = new NpgsqlConnection(DbConstants.DB_CONNECTIONSTRING);
    }



    public async Task<int> CreateAsync(Purchased_product obj)
    {
        try
        {
            await _connection.OpenAsync();

            string query = "INSERT INTO public.purchased_products(worker_id, product_id, product_amount, client_id, total_price, description, create_date, update_date)" +
                "VALUES (@worker_id, @product_id, @product_amount, @client_id, @total_price , @description, @create_date, @update_date);";

            await using (var command = new NpgsqlCommand(query, _connection))
            {
                command.Parameters.AddWithValue("worker_id", obj.worker_id);
                command.Parameters.AddWithValue("product_id", obj.product_id);
                command.Parameters.AddWithValue("product_amount", obj.product_amount);
                command.Parameters.AddWithValue("client_id", obj.client_id);
                command.Parameters.AddWithValue("total_price", obj.total_price);
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



    public async Task<IList<Purchased_product>> GetAllAsync()
    {
        try
        {
            await _connection.OpenAsync();
            var list = new List<Purchased_product>();
            string query = $"select * from purchased_products order by id;";
            await using (var command = new NpgsqlCommand(query, _connection))
            {
                await using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        var purchased_Product = new Purchased_product();
                        purchased_Product.id = reader.GetInt64(0);
                        purchased_Product.worker_id = (int)reader.GetInt64(1);
                        purchased_Product.product_id = (int)reader.GetInt64(2);
                        purchased_Product.client_id = (int)reader.GetInt64(3);
                        purchased_Product.product_amount = (int)reader.GetInt64(4);
                        purchased_Product.total_price = reader.GetString(5);
                        purchased_Product.description = reader.GetString(6);
                        purchased_Product.create_date = reader.GetString(7);
                        purchased_Product.update_date = reader.GetString(8);
                        list.Add(purchased_Product);
                    }
                }
            }
            return list;
        }
        catch
        {
            return new List<Purchased_product>();
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
            
                string query = $"DELETE FROM public.purchased_products WHERE id={id};";
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


        public async Task<IList<Purchased_product>> SearchAsync(string obj)
        {
        try
        {
            await _connection.OpenAsync();
            var list = new List<Purchased_product>();
            string query = $"select * from purchased_products where create_date like '%{obj}%';";
            await using (var command = new NpgsqlCommand(query, _connection))
            {
                await using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        var purchased_Product = new Purchased_product();
                        purchased_Product.id = reader.GetInt64(0);
                        purchased_Product.worker_id = (int)reader.GetInt64(1);
                        purchased_Product.product_id = (int)reader.GetInt64(2);
                        purchased_Product.client_id = (int)reader.GetInt64(3);
                        purchased_Product.product_amount = (int)reader.GetInt64(4);
                        purchased_Product.total_price = reader.GetString(5);
                        purchased_Product.description = reader.GetString(6);
                        purchased_Product.create_date = reader.GetString(7);
                        purchased_Product.update_date = reader.GetString(8);
                        list.Add(purchased_Product);
                    }
                }
            }
            return list;
        }
        catch
        {
            return new List<Purchased_product>();
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }


    public async Task<int> DeleteClientsAsync(int propertyJson)
    {
        try
        {

            await _connection.OpenAsync();
            
            string query = $"DELETE FROM public.purchased_products WHERE client_id={propertyJson};";
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


    public async Task<int> DeleteWorkessAsync(int propertyJson)
    {
        try
        {

            await _connection.OpenAsync();

            string query = $"DELETE FROM public.purchased_products WHERE worker_id={propertyJson};";
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

    public async Task<int> DeleteProductsAsync(int propertyJson)
    {
        try
        {

            await _connection.OpenAsync();

            string query = $"DELETE FROM public.purchased_products WHERE product_id={propertyJson};";
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


}
