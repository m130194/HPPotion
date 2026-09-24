using HarryPotterPotions.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
//using System.Text.Json;

using System.Net.Http;
using System.Text;
using HarryPotterPotions.Models;

namespace HarryPotterPotions.Services
{
    public class APIService
    {
        HttpClient _client = new HttpClient();
        const string baseURL = "https://api.potterdb.com/";

        public async Task<List<ActualPotion>> GetPotionsAsync(string searchParam)
        {
            string apiURL = $"{baseURL}v1/potions?filter[name_cont]={searchParam}";
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, apiURL);

            HttpResponseMessage response = await _client.SendAsync(request);

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Server responded with: {response.StatusCode}");
            }

            string contentString = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeAnonymousType(
                contentString,
                new
                {
                    data = new List<Potion>()
                });

            List<Potion> potions = result!.data;


            //List<Potion> potions = JsonConvert.DeserializeObject<List<Potion>>(contentString) ?? [];

            return potions.ConvertAll<ActualPotion>(x=>x);

        }
    }
}
