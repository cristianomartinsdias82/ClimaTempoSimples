using ClimaTempoSimples.Application.Common;
using MediatR;

namespace ClimaTempoSimples.Application.Queries.ListTodaysTopColdestCities
{
    public class ListTodaysTopColdestCitiesRequest : IRequest<ListTodaysTopColdestCitiesResponse>
    {
        public PaginationArgs PaginationArgs { get; set; }
    }
}
