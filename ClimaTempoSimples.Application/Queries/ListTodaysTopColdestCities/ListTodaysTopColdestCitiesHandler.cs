using ClimaTempoSimples.Application.Queries.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ClimaTempoSimples.Application.Queries.ListTodaysTopColdestCities
{
    internal sealed class ListTodaysTopColdestCitiesHandler : IRequestHandler<ListTodaysTopColdestCitiesRequest, ListTodaysTopColdestCitiesResponse>
    {
        private readonly IWeatherForecastRepository _weatherForecastRepository;

        public ListTodaysTopColdestCitiesHandler(IWeatherForecastRepository weatherForecastRepository)
        {
            _weatherForecastRepository = weatherForecastRepository ?? throw new ArgumentNullException($"{nameof(weatherForecastRepository)} argument cannot be null");
        }

        public async Task<ListTodaysTopColdestCitiesResponse> Handle(ListTodaysTopColdestCitiesRequest request, CancellationToken cancellationToken)
        {
            var data = await _weatherForecastRepository.FetchTodaysTopColdestCitiesAsync(request.PaginationArgs, cancellationToken);

            return new ListTodaysTopColdestCitiesResponse
            {
                TopColdestCities = data
            };
        }
    }
}
