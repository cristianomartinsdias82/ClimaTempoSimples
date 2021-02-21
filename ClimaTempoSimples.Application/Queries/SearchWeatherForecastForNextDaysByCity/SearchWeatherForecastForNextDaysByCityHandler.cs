using ClimaTempoSimples.Application.Queries.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ClimaTempoSimples.Application.Queries.SearchWeatherForecastForNextDaysByCity
{
    internal sealed class SearchWeatherForecastForNextDaysByCityHandler : IRequestHandler<SearchWeatherForecastForNextDaysByCityRequest, SearchWeatherForecastForNextDaysByCityResponse>
    {
        private readonly IWeatherForecastRepository _weatherForecastRepository;

        public SearchWeatherForecastForNextDaysByCityHandler(IWeatherForecastRepository weatherForecastRepository)
        {
            _weatherForecastRepository = weatherForecastRepository ?? throw new ArgumentNullException($"{nameof(weatherForecastRepository)} argument cannot be null");
        }

        public async Task<SearchWeatherForecastForNextDaysByCityResponse> Handle(SearchWeatherForecastForNextDaysByCityRequest request, CancellationToken cancellationToken)
        {
            var data = await _weatherForecastRepository.SearchWeatherForecastForNextDaysByCityAsync(request.City, request.DaysFromNow, cancellationToken);

            return new SearchWeatherForecastForNextDaysByCityResponse
            {
                WeatherForecasts = data
            };
        }
    }
}
