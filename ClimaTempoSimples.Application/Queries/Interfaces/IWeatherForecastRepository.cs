using ClimaTempoSimples.Application.Common;
using ClimaTempoSimples.Application.Queries.ListCitiesWithForecasts;
using ClimaTempoSimples.Application.Queries.ListTodaysTopColdestCities;
using ClimaTempoSimples.Application.Queries.ListTodaysTopHottestCities;
using ClimaTempoSimples.Application.Queries.SearchWeatherForecastForNextDaysByCity;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ClimaTempoSimples.Application.Queries.Interfaces
{
    public interface IWeatherForecastRepository
    {
        Task<IEnumerable<ListTodaysTopColdestCitiesDto>> FetchTodaysTopColdestCitiesAsync(PaginationArgs paginationArgs, CancellationToken cancellationToken);
        Task<IEnumerable<ListTodaysTopHottestCitiesDto>> FetchTodaysTopHottestCitiesAsync(PaginationArgs paginationArgs, CancellationToken cancellationToken);
        Task<IEnumerable<SearchWeatherForecastForNextDaysByCityDto>> SearchWeatherForecastForNextDaysByCityAsync(string city, int daysFromNow, CancellationToken cancellationToken);
        Task<IEnumerable<ListCitiesWithForecastsDto>> ListCitiesWithForecastsAsync(PaginationArgs paginationArgs, CancellationToken cancellationToken);
    }
}
