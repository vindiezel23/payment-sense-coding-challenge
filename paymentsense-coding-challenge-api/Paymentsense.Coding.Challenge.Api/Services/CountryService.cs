using Newtonsoft.Json;
using Paymentsense.Coding.Challenge.Api.Extensions;
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
            client.BaseAddress = new Uri("https://restcountries.eu/rest/v2/");
            //client.DefaultRequestHeaders.Add("Accept",
              //  "application/json");
            Client = client;
        }

        public async Task<IEnumerable<CountryInfo>> GetCountries()
        {
            try
            {
                var response = await Client.GetAsync(
                    "all");

                if (response.IsSuccessStatusCode)
                {
                    return response.ContentAsType<IEnumerable<CountryInfo>>();
                }

                return null;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<CountryInfo> GetCountryInfo(string alpha3Code)
        {
            var response = await Client.GetAsync(
                string.Format("https://restcountries.eu/rest/v2/alpha/{0}", alpha3Code));

            if (response.IsSuccessStatusCode)
            {
                return response.ContentAsType<CountryInfo>();
            }

            return null;
        }
    }
}
