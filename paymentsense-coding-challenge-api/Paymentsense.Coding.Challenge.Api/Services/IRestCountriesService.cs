using System.Collections.Generic;
using System.Threading.Tasks;
using Paymentsense.Coding.Challenge.Api.Dtos;
using Paymentsense.Coding.Challenge.Api.Models;

namespace Paymentsense.Coding.Challenge.Api.Services
{
    public interface IRestCountriesService
    {
        Task<IEnumerable<CountryDto>> GetAllCountries();
        Task<Country> GetByName(string name);
    }
}