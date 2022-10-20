using System;
using System.Collections.Generic;
using System.Text;

using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using project1.models;

namespace project1.services
{
    public class APIService
    {
        const string apiKey = "ad87742fc092569b6487d31d41e5f30d";

        public async Task<string> GetCurrentTemp(string city, string unit)
        {
            HttpClient client = new HttpClient();

            HttpResponseMessage response = await client.GetAsync($"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={apiKey}&units={unit}");

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string content = await response.Content.ReadAsStringAsync();

                WeatherModel root = JsonConvert.DeserializeObject<WeatherModel>(content);

                return root.main.temp.ToString();
            }

            return null;

        }

        public async Task<string> GetCityDetails(string city)
        {
            HttpClient client = new HttpClient();

            HttpResponseMessage response = await client.GetAsync($"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={apiKey}");

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string content = await response.Content.ReadAsStringAsync();

                WeatherModel root = JsonConvert.DeserializeObject<WeatherModel>(content);

                string cityDetails = $"{city} , {root.sys.country} \n {root.coord.lat} , {root.coord.lon}";

                return cityDetails;
            }

            return null;

        }

        public async Task<string> GetMinTemp(string city, string unit)
        {
            HttpClient client = new HttpClient();

            HttpResponseMessage response = await client.GetAsync($"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={apiKey}&units={unit}");

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string content = await response.Content.ReadAsStringAsync();

                WeatherModel root = JsonConvert.DeserializeObject<WeatherModel>(content);

                return root.main.temp_min.ToString();
            }

            return null;

        }

        public async Task<string> GetMaxTemp(string city, string unit)
        {
            HttpClient client = new HttpClient();

            HttpResponseMessage response = await client.GetAsync($"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={apiKey}&units={unit}");

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string content = await response.Content.ReadAsStringAsync();

                WeatherModel root = JsonConvert.DeserializeObject<WeatherModel>(content);

                return root.main.temp_max.ToString();
            }

            return null;

        }

        public async Task<string> GetHumidity(string city)
        {
            HttpClient client = new HttpClient();

            HttpResponseMessage response = await client.GetAsync($"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={apiKey}");

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string content = await response.Content.ReadAsStringAsync();

                WeatherModel root = JsonConvert.DeserializeObject<WeatherModel>(content);

                return root.main.humidity.ToString();
            }

            return null;

        }

        public async Task<string> GetWindSpeed(string city, string unit)
        {
            HttpClient client = new HttpClient();

            HttpResponseMessage response = await client.GetAsync($"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={apiKey}&units={unit}");

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string content = await response.Content.ReadAsStringAsync();

                WeatherModel root = JsonConvert.DeserializeObject<WeatherModel>(content);

                return root.wind.speed.ToString();
            }

            return null;

        }

        public async Task<string> GetPressure(string city)
        {
            HttpClient client = new HttpClient();

            HttpResponseMessage response = await client.GetAsync($"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={apiKey}");

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string content = await response.Content.ReadAsStringAsync();

                WeatherModel root = JsonConvert.DeserializeObject<WeatherModel>(content);

                return root.main.pressure.ToString();
            }

            return null;

        }

        public async Task<string> GetCondition(string city)
        {
            HttpClient client = new HttpClient();

            HttpResponseMessage response = await client.GetAsync($"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={apiKey}");

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string content = await response.Content.ReadAsStringAsync();

                WeatherModel root = JsonConvert.DeserializeObject<WeatherModel>(content);

                return root.weather[0].main;
            }

            return null;

        }
    }
}
