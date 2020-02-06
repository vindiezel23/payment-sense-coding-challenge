using Microsoft.AspNetCore.Mvc;
using Paymentsense.Coding.Challenge.Api.Services;
using System.Threading.Tasks;

namespace Paymentsense.Coding.Challenge.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PaymentsenseCodingChallengeController : ControllerBase
    {
        private readonly CountryService _countryService;
        public PaymentsenseCodingChallengeController(
                CountryService countryService
            )
        {
            _countryService = countryService;
        }


        [HttpGet("countries")]
        [ResponseCache(Duration =60)]
        public async Task<IActionResult> GetCountries()
        {
            var countries = await _countryService.GetCountries();
            return Ok(countries);
        }

        [HttpGet("country/{alpha3Code}")]
        [ResponseCache(Duration = 60)]
        public async Task<IActionResult> GetCountryByCode(
                [FromRoute] string alpha3Code
            )
        {
            var country = await _countryService.GetCountryInfo(alpha3Code);
            return Ok(country);
        }
    }
}
