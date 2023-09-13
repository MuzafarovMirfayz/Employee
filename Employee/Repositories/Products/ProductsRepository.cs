using Employee.Constants;
using Employee.Entities.Clients;
using Employee.Entities.Products;
using Employee.FileJson;
using Employee.Repositories.Purchased_products;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Repositories.Products;

public class ProductsRepository
{
    protected readonly NpgsqlConnection _connection;
    public ProductsRepository()
    {
        _connection = new NpgsqlConnection(DbConstants.DB_CONNECTIONSTRING);
    }



    public async Task<int> CreateAsync(Product obj)
    {
        try
        {
            await _connection.OpenAsync();

            string query = "INSERT INTO public.product(name,  price,  description, create_date, update_date, image_path)" +
                "VALUES (@name, @price, @description, @create_date, @update_date, @image_path);";

            await using (var command = new NpgsqlCommand(query, _connection))
            {
                command.Parameters.AddWithValue("name", obj.name);
                command.Parameters.AddWithValue("price", obj.price);
                command.Parameters.AddWithValue("description", obj.description);
                command.Parameters.AddWithValue("create_date", obj.create_date);
                command.Parameters.AddWithValue("update_date", obj.update_date);
                command.Parameters.AddWithValue("image_path", obj.image);


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



    public async Task<IList<Product>> GetAllAsync()
    {
        try
        {
            await _connection.OpenAsync();
            var list = new List<Product>();
            string query = $"select * from product order by id ;"; 
            await using (var command = new NpgsqlCommand(query, _connection))
            {
                await using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        var product = new Product();
                        product.id = reader.GetInt64(0);
                        product.name = reader.GetString(1);
                        product.price = reader.GetString(2);
                        product.description = reader.GetString(3);
                        product.create_date = reader.GetString(4);
                        product.update_date = reader.GetString(5);
                        product.image = reader.GetString(6);
                        list.Add(product);
                    }
                }
            }
            return list;
        }
        catch
        {
            return new List<Product>();
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
            
                await purchased_ProductsRepository.DeleteProductsAsync(id);
                string query = $"DELETE FROM public.product WHERE id={id};";
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





    public async Task<IList<Product>> SearchAsync(string obj)
    {
        try
        {
            await _connection.OpenAsync();
            var list = new List<Product>();
            string query = $"select * from product where name  like '%{obj}%';";
            await using (var command = new NpgsqlCommand(query, _connection))
            {
                await using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        var product = new Product();
                        product.id = reader.GetInt64(0);
                        product.name = reader.GetString(1);
                        product.price = reader.GetString(2);
                        product.description = reader.GetString(3);
                        product.create_date = reader.GetString(4);
                        product.update_date = reader.GetString(5);
                        product.image = reader.GetString(6);
                        list.Add(product);
                    }
                }
            }
            return list;
        }
        catch
        {
            return new List<Product>();
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
            string query = $"select * from product where id = {a};";
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


