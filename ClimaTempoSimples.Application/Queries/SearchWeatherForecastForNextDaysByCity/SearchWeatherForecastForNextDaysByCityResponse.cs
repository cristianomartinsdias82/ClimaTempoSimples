using System;
using System.Collections.Generic;

namespace ClimaTempoSimples.Application.Queries.SearchWeatherForecastForNextDaysByCity
{
    public class SearchWeatherForecastForNextDaysByCityResponse
    {
        public IEnumerable<SearchWeatherForecastForNextDaysByCityDto> WeatherForecasts { get; set; } = new List<SearchWeatherForecastForNextDaysByCityDto>();
    }
}
