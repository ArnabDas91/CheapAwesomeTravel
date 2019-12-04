using CheapAwesomeTravel.Repositories.Classes;
using CheapAwesomeTravel.Repositories.Utility;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Net.Http;
using Newtonsoft.Json;

namespace CheapAwesomeTravel.Repositories
{
    public class ConsumeAPI : IConsumeAPI
    {
        private string _apiURL;
        public ConsumeAPI(string apiURL)
        {
            _apiURL = apiURL;
        }

        async Task<List<Hotels>> IConsumeAPI.GetHotelsFromApi(int destinationid, int nights, string code)
        {
            List<Hotels> hotels = null;
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(_apiURL);
                    var responseTask = await client.GetAsync("findBargain?destinationid=" + destinationid + "&nights=" + nights + "&code=" + code);
                    if (responseTask.IsSuccessStatusCode)
                    {
                        var jsonString = await responseTask.Content.ReadAsStringAsync();
                        hotels = JsonConvert.DeserializeObject<List<Hotels>>(jsonString);
                        ClsUtility.WriteJSONFile(jsonString);
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
