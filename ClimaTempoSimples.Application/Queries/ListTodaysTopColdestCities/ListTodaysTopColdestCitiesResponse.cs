using System.Collections.Generic;

namespace ClimaTempoSimples.Application.Queries.ListTodaysTopColdestCities
{
    public class ListTodaysTopColdestCitiesResponse
    {
        public IEnumerable<ListTodaysTopColdestCitiesDto> TopColdestCities { get; set; } = new List<ListTodaysTopColdestCitiesDto>();
    }
}
