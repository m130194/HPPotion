using HarryPotterPotions.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Net.Http;
using System.Text;
using HarryPotterPotions.Models;
using System.Text.Json.Nodes;

namespace HarryPotterPotions.Services
{
    public class APIService
    {
        HttpClient _client = new HttpClient();
        const string baseURL = "https://api.potterdb.com/";

        public async Task<List<ActualPotion>> GetPotionsAsync(string SearchParam)
        {
            string apiURL = $"{baseURL}v1/potions?filter[name_cont]={SearchParam}";
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, apiURL);

            HttpResponseMessage response = await _client.SendAsync(request);

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Server responded with: {response.StatusCode}");
            }

            string contentString = await response.Content.ReadAsStringAsync();

            //var result = JsonConvert.DeserializeAnonymousType(
            //    contentString,
            //    new
            //    {
            //        data = new List<Potion>()
            //    });

            //List<Potion> potions = result!.data;

            //return potions.ConvertAll<ActualPotion>(x => x);
            
            JsonNode forecastNode = JsonNode.Parse(contentString);

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                WriteIndented = true
            };

            JsonNode data = forecastNode!["data"];

            JsonArray potionsData = data.AsArray();

            List<ActualPotion> potions = new();

            foreach (JsonNode? potionData in potionsData)
            {
                string Id = potionData?["id"].ToString();
                string Name = potionData?["attributes"]["name"]?.ToString();
                string Ingredients = potionData?["attributes"]["ingredients"]?.ToString();

                ActualPotion potion = new ActualPotion
                {
                    Id = Id,
                    Name = Name,
                    Ingredients = Ingredients
                };
                potions.Add(potion);


            }
            
            return potions;
        }
    }
}
