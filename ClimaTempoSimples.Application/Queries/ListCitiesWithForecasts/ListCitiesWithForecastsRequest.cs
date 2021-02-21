using ClimaTempoSimples.Application.Common;
using MediatR;

namespace ClimaTempoSimples.Application.Queries.ListCitiesWithForecasts
{
    public class ListCitiesWithForecastsRequest : IRequest<ListCitiesWithForecastsResponse>
    {
        public PaginationArgs PaginationArgs { get; set; }
    }
}
