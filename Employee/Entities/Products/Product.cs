using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Entities.Products;

public class Product
{
    public long id { get; set; }
    [MaxLength(25)]
    public string name { get; set; } = string.Empty;
    public string price { get; set; } = string.Empty;
    public string image { get; set; } = string.Empty;
    public string description { get; set; } = string.Empty;
    public string create_date { get; set; } = string.Empty;
    public string update_date { get; set; } = string.Empty;


}
