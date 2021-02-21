using System.Collections.Generic;

namespace ClimaTempoSimples.Application.Queries.ListTodaysTopHottestCities
{
    public class ListTodaysTopHottestCitiesResponse
    {
        public IEnumerable<ListTodaysTopHottestCitiesDto> TopHottestCities { get; set; } = new List<ListTodaysTopHottestCitiesDto>();
    }
}
