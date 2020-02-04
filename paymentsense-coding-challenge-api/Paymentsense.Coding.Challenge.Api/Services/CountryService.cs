using Paymentsense.Coding.Challenge.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Paymentsense.Coding.Challenge.Api.Services
{
    public class CountryService
    {
        public HttpClient Client { get; }

        public CountryService(HttpClient client)
        {
            client.BaseAddress = new Uri("https://restcountries.eu/rest/v2");
            client.DefaultRequestHeaders.Add("Accept",
                "application/json");
            Client = client;
        }

        public async Task<IEnumerable<Country>> GetCountries()
        {
            var response = await Client.GetAsync(
                "/all?fields=alpha3code;name;flag");

            response.EnsureSuccessStatusCode();

            using var responseStream = await response.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync
                <IEnumerable<Country>>(responseStream);
        }

        public async Task<CountryInfo> GetCountryInfo(string alpha3Code)
        {
            var response = await Client.GetAsync(
                string.Format("https://restcountries.eu/rest/v2/alpha/{0}", alpha3Code));

            response.EnsureSuccessStatusCode();

            using var responseStream = await response.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync
                <CountryInfo>(responseStream);
        }
    }
}
