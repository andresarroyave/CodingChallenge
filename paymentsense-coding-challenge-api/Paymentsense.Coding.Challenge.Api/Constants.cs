using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Paymentsense.Coding.Challenge.Api
{
    public class Constants
    {

        public static class Resources
        {

            public const string RestCountriesClientName = "restCountries";
            public const string RestCountriesBaseUrl = "https://restcountries.eu/rest/v2/";
            public const string RestCountriesGetAllEndpoint = "all";
            public const string RestCountriesGetByNameEndpoint = "name/{0}";
        }
    }
}
