using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Script.Serialization;

namespace Simple_Weather_Bot.API
{
    public class WeatherAPI
    {
        public static async Task<WeatherModel> GetWeatherInCity(string city)
        {
            try
            {
                string endpoint = getRequestURLForCity(city);
                using (WebClient client = new WebClient())
                {
                    var jsonResult = await client.DownloadStringTaskAsync(endpoint).ConfigureAwait(false);
                    var serializer = new JavaScriptSerializer();
                    WeatherModel response = serializer.Deserialize<WeatherModel>(jsonResult);
                    Debug.WriteLine(response.ToString());
                    return response;
                }

            } catch (Exception e)
            {
                //handle exception
                throw e;
            }
        }

      
        
        private static string getRequestURLForCity(string city)
        {
            return $"http://api.openweathermap.org/data/2.5/weather?q={city}&appid=2043139f9ac7792e48cd8943e3bdf159";
        }
    }
}