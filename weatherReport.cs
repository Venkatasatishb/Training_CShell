// Weather Report

using System.Net;
using System.IO;
using System;
using nsTools;
using Newtonsoft.Json.Linq;
    
class WheatherReport
{
    static void Main(string[] args)
    {
        Tools tools = new Tools();
        tools.print("Enter Cit Name: ");
        string cityName = tools.input();

        HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format("https://api.openweathermap.org/data/2.5/weather?q=" + cityName + "&units=metric&appid=201ac1b1456985494f5e9f7c1c258d45"));
        HttpWebResponse WebResp = (HttpWebResponse)WebReq.GetResponse();

        StreamReader reader = new StreamReader(WebResp.GetResponseStream());
        string jsonString = reader.ReadToEnd();
        JObject json = JObject.Parse(jsonString);
        JObject main = JObject.Parse(json["main"].ToString());
        Console.WriteLine(main["temp"].ToString());
        Console.WriteLine("The temperature in " + cityName + " is " + main["temp"].ToString() + " degrees celsius.");

    }
}








// using System.Net;
// using System.IO;
// using Newtonsoft.Json;

// private static void start_get()
// {
//     HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format("https://api.coinmarketcap.com/v1/ticker/"));

//     WebReq.Method = "GET";

//     HttpWebResponse WebResp = (HttpWebResponse)WebReq.GetResponse();

//     Console.WriteLine(WebResp.StatusCode);
//     Console.WriteLine(WebResp.Server);

//     string jsonString;
//     using (Stream stream = WebResp.GetResponseStream())   //modified from your code since the using statement disposes the stream automatically when done
//     {
//        StreamReader reader = new StreamReader(stream, System.Text.Encoding.UTF8);
//        jsonString = reader.ReadToEnd();
//     }

//     List<Item> items = JsonConvert.DeserializeObject<List<Item>>(jsonString);

//     Console.WriteLine(items.Count);     //returns 921, the number of items on that page
// }