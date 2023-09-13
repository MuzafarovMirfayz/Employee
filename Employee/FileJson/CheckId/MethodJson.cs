using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Automation.Peers;

namespace Employee.FileJson;

public class MethodJson
{
    public static void ForAdd(int id)
    {
        try
        {
            string JsonFilePath = "Json/AllCheckedId.json";
            string Jsoncontent = File.ReadAllText(JsonFilePath);
            var data = JsonConvert.DeserializeObject<List<PropertyJson>>(Jsoncontent);

            PropertyJson pro = new PropertyJson()
            {
                Id = id
            };
            data.Add(pro);
            var jsoncontent = JsonConvert.SerializeObject(data);
            File.WriteAllText(JsonFilePath, jsoncontent);
        }
        catch 
        {

        }
        

    }

    public static void delete(int id)
    {
        try
        {
            string JsonFilePath = "Json/AllCheckedId.json";
            string Jsoncontent = File.ReadAllText(JsonFilePath);
            var date = JsonConvert.DeserializeObject<List<PropertyJson>>(Jsoncontent);
            int i = 0;
            foreach (var item in date)
            {
                if(item.Id == id)
                {
                    break;
                }
                i+=1;
            }
            date.RemoveAt(i);
            var jsoncontent = JsonConvert.SerializeObject(date);
            File.WriteAllText(JsonFilePath, jsoncontent);
        }
        catch 
        {

        }
    }
    public static List<PropertyJson>? AnlyRead()
    {
        string JsonFilePath = "Json/AllCheckedId.json";
        string Jsoncontent = File.ReadAllText(JsonFilePath);
        var date = JsonConvert.DeserializeObject<List<PropertyJson>>(Jsoncontent);
        return date;
    }


    public static void Clear()
    {
        string JsonFilePath = "Json/AllCheckedId.json";
        string Jsoncontent = File.ReadAllText(JsonFilePath);
        File.WriteAllText(JsonFilePath, "[]");

    }

}
