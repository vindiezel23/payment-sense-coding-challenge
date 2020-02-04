using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Paymentsense.Coding.Challenge.Api.Extensions
{
    public static class HttpResponseExtensions
    {
        public static T ContentAsType<T>(this HttpResponseMessage response)
        {
            var data = response.Content.ReadAsStringAsync().Result;
            return string.IsNullOrEmpty(data) ?
                           default(T) :
                           JsonConvert.DeserializeObject<T>(data);
        }
    }
}
