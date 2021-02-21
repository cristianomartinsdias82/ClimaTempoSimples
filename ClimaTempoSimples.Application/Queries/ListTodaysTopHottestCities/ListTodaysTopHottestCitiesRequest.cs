using ClimaTempoSimples.Application.Common;
using MediatR;

namespace ClimaTempoSimples.Application.Queries.ListTodaysTopHottestCities
{
    public class ListTodaysTopHottestCitiesRequest : IRequest<ListTodaysTopHottestCitiesResponse>
    {
        public PaginationArgs PaginationArgs { get; set; }
    }
}
