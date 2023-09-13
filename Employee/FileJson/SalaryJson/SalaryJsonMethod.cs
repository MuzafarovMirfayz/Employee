using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.FileJson.SalaryJson
{
    public class SalaryJsonMethod
    {

        public static void ForAdd(int id, int salary)
        {
            try
            {
                string JsonFilePath = "Json/Salary.json";
                string Jsoncontent = File.ReadAllText(JsonFilePath);
                var data = JsonConvert.DeserializeObject<List<SalaryJsonProperty>>(Jsoncontent);

                SalaryJsonProperty pro = new SalaryJsonProperty()
                {
                    Id = id,
                    Salary = salary
                };
                data.Add(pro);
                var jsoncontent = JsonConvert.SerializeObject(data);
                File.WriteAllText(JsonFilePath, jsoncontent);
            }
            catch
            {

            }
        }
        public static void Clear()
        {
            string JsonFilePath = "Json/Salary.json";
            string Jsoncontent = File.ReadAllText(JsonFilePath);
            File.WriteAllText(JsonFilePath, "[]");

        }


        public static List<SalaryJsonProperty>? AnlyRead()
        {
            string JsonFilePath = "Json/Salary.json";
            string Jsoncontent = File.ReadAllText(JsonFilePath);
            var date = JsonConvert.DeserializeObject<List<SalaryJsonProperty>>(Jsoncontent);
            return date;
        }



    }
}
