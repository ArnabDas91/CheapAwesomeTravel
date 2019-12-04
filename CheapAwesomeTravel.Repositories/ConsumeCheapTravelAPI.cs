using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using CheapAwesomeTravel.Repositories.Classes;
using Newtonsoft.Json;
using CheapAwesomeTravel.Repositories.Utility;

namespace CheapAwesomeTravel.Repositories
{
    public class ConsumeCheapTravelAPI : IConsumeCheapTravelAPI
    {
        private string _apiURL;
        public ConsumeCheapTravelAPI(string apiURL)
        {
            _apiURL = apiURL;
        }
        async Task<List<Hotels>> IConsumeCheapTravelAPI.ConsumeService(int destinationid, int nights, string code)
        {
            List<Hotels> hotels = null;
            string url = _apiURL;
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(url);
                    var responseTask = await client.GetAsync("CheapAwesomeApi?destinationid=" + destinationid + "&nights=" + nights + "&code=" + code);
                    if (responseTask.IsSuccessStatusCode)
                    {
                        var jsonString = await responseTask.Content.ReadAsStringAsync();
                        hotels = JsonConvert.DeserializeObject<List<Hotels>>(jsonString);
                    }
                    else
                    {
                        hotels = Enumerable.Empty<Hotels>().ToList();
                    }
                    return hotels;
                }
            }
            catch (Exception ex)
            {
                ClsUtility.WriteLogFile(ex.Message.ToString());
                return Enumerable.Empty<Hotels>().ToList();
            }
        }
    }
}
