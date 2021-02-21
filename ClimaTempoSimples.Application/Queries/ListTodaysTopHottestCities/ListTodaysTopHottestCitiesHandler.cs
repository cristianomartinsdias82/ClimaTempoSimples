using ClimaTempoSimples.Application.Queries.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ClimaTempoSimples.Application.Queries.ListTodaysTopHottestCities
{
    internal sealed class ListTodaysTopHottestCitiesHandler : IRequestHandler<ListTodaysTopHottestCitiesRequest, ListTodaysTopHottestCitiesResponse>
    {
        private readonly IWeatherForecastRepository _weatherForecastRepository;

        public ListTodaysTopHottestCitiesHandler(IWeatherForecastRepository weatherForecastRepository)
        {
            _weatherForecastRepository = weatherForecastRepository ?? throw new ArgumentNullException($"{nameof(weatherForecastRepository)} argument cannot be null");
        }

        public async Task<ListTodaysTopHottestCitiesResponse> Handle(ListTodaysTopHottestCitiesRequest request, CancellationToken cancellationToken)
        {
            var data = await _weatherForecastRepository.FetchTodaysTopHottestCitiesAsync(request.PaginationArgs, cancellationToken);

            return new ListTodaysTopHottestCitiesResponse
            {
                TopHottestCities = data
            };
        }
    }
}
