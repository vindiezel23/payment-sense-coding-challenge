using System;
namespace Paymentsense.Coding.Challenge.Api.Models
{
    public class Country
    {
        public string Alpha3Code { get; set; }
        public string Name { get; set; }
        public string Flag { get; set; }
    }

    public class CountryInfo : Country
    {
        public int Population { get; set; }
        public string[] Timezones { get; set; }
        public Currency[] Currencies { get; set; }
        public Language[] Languages { get; set; }
    }
}
