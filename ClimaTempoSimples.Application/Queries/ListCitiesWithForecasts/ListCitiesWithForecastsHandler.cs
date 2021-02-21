using ClimaTempoSimples.Application.Queries.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ClimaTempoSimples.Application.Queries.ListCitiesWithForecasts
{
    internal sealed class ListCitiesWithForecastsHandler : IRequestHandler<ListCitiesWithForecastsRequest, ListCitiesWithForecastsResponse>
    {
        private readonly IWeatherForecastRepository _weatherForecastRepository;

        public ListCitiesWithForecastsHandler(IWeatherForecastRepository weatherForecastRepository)
        {
            _weatherForecastRepository = weatherForecastRepository ?? throw new ArgumentNullException($"{nameof(weatherForecastRepository)} argument cannot be null");
        }

        public async Task<ListCitiesWithForecastsResponse> Handle(ListCitiesWithForecastsRequest request, CancellationToken cancellationToken)
        {
            var data = await _weatherForecastRepository.ListCitiesWithForecastsAsync(request.PaginationArgs, cancellationToken);

            return new ListCitiesWithForecastsResponse
            {
                CitiesWithForecasts = data,
                GroupedCitiesWithForecasts = GroupData(data)
            };
        }

        private IDictionary<string, IEnumerable<ListCitiesWithForecastsDto>> GroupData(IEnumerable<ListCitiesWithForecastsDto> cities)
        {
            var groupedData = new Dictionary<string, IEnumerable<ListCitiesWithForecastsDto>>();
            var dataGroups = cities.GroupBy(x => x.State);

            foreach (var group in dataGroups)
                groupedData[group.Key] = group.Where(x => x.State == group.Key).ToList();

            return groupedData;
        }
    }
}
