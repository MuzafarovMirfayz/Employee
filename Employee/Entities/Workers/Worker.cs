using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Entities.Workers
{

    public class Worker
    {
        public long id { get; set; }

        [MaxLength(25)]
        public string first_name { get; set; } = string.Empty;

        [MaxLength(25)]
        public string last_name { get; set; } = string.Empty;

        [MaxLength(13)]
        public string number { get; set; } = string.Empty;

        [MaxLength(9)]
        public string passport_seria { get; set; } = string.Empty;

        public string description { get; set; } = string.Empty;

        public string create_date { get; set; } = string.Empty;
        public string update_date { get; set; } = string.Empty;

        public string image { get; set; } = string.Empty;


    }
}