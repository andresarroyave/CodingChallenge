using Paymentsense.Coding.Challenge.Api.Dtos;
using Paymentsense.Coding.Challenge.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Paymentsense.Coding.Challenge.Api.Services
{
    public class RestCountriesService : IRestCountriesService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public RestCountriesService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IEnumerable<CountryDto>> GetAllCountries()
        {
            var response = await GetRequest(Constants.Resources.RestCountriesGetAllEndpoint);

            return JsonSerializer.Deserialize<List<CountryDto>>(response, 
                new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                });
        }

        public async Task<Country> GetByName(string name)
        {
            var endpoint = string.Format(Constants.Resources.RestCountriesGetByNameEndpoint, name);
            var response = await GetRequest(endpoint);

            return JsonSerializer.Deserialize<Country[]>(response,
                new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                }).First();
        }

        private async Task<string> GetRequest(string endpoint)
        {
            HttpClient client = _httpClientFactory.CreateClient(Constants.Resources.RestCountriesClientName);

            var request = new HttpRequestMessage(HttpMethod.Get, endpoint);

            var response = await client.SendAsync(request);

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }

    }
}
