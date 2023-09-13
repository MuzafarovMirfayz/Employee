using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Entities.Purchased_products;

public class Purchased_product
{
    public  long id { get; set; }

    public int worker_id { get; set; }

    public int product_id { get; set; }

    public int client_id { get; set; }

    public int product_amount { get; set; }

    public string total_price { get; set; } = string.Empty;


    public string description { get; set; } = string.Empty;
    public string create_date { get; set; } = string.Empty;
    public string update_date { get; set; } = string.Empty;
}
