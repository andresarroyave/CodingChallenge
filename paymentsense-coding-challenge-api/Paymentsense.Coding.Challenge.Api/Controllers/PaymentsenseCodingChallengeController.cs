using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Paymentsense.Coding.Challenge.Api.Dtos;
using Paymentsense.Coding.Challenge.Api.Models;
using Paymentsense.Coding.Challenge.Api.Services;

namespace Paymentsense.Coding.Challenge.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PaymentsenseCodingChallengeController : ControllerBase
    {
        private readonly IRestCountriesService _restCountriesService;
        private readonly IMemoryCache _memoryCache;

        public PaymentsenseCodingChallengeController(IRestCountriesService restCountriesService, IMemoryCache memoryCache)
        {
            _restCountriesService = restCountriesService;
            _memoryCache = memoryCache;
        }

        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<CountryDto>>> Get()
        {
            var countries = await _memoryCache.GetOrCreateAsync("Countries",
                async(cacheEntry) => {
                    return await _restCountriesService.GetAllCountries();
                });

            return countries.ToList();

        }

        [HttpGet("{name}")]
        public async Task<ActionResult<Country>> Get(string name) =>
            await _memoryCache.GetOrCreateAsync("Country-" + name,
                async (cacheEntry) =>
                    await _restCountriesService.GetByName(name));

    }
}
