using System.IO;
using System;
using System.Configuration;
using Newtonsoft.Json.Linq;

public class ConfigReader
{
    public string get(string keyword)
    {
        string result = "";
        try
        {
            string filepath = File.ReadAllText(Path.Combine(System.IO.Directory.GetCurrent‌​Directory(), "..\\..\\..\\appsettings.json"));
            JObject json = JObject.Parse(filepath);
            result = json[keyword].ToString();
        }
        catch (Exception)
        {
            Console.WriteLine("Error reading config");
        }
        return result;
    }

}