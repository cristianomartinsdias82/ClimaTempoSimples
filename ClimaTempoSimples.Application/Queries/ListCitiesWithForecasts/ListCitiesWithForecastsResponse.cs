using System.Collections.Generic;

namespace ClimaTempoSimples.Application.Queries.ListCitiesWithForecasts
{
    public class ListCitiesWithForecastsResponse
    {
        public IEnumerable<ListCitiesWithForecastsDto> CitiesWithForecasts { get; set; } = new List<ListCitiesWithForecastsDto>();
        public IDictionary<string, IEnumerable<ListCitiesWithForecastsDto>> GroupedCitiesWithForecasts { get; set; } = new Dictionary<string, IEnumerable<ListCitiesWithForecastsDto>>();
    }
}
