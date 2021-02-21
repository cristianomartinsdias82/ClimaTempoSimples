using ClimaTempoSimples.Application.Common;
using ClimaTempoSimples.Application.Queries.ListTodaysTopColdestCities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ClimaTempoSimples.Controllers
{
    public class ListTodaysTopColdestCitiesController : ClimaTempoSimplesController
    {
        private readonly IMediator _mediator;

        public ListTodaysTopColdestCitiesController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException($"{mediator} argument cannot be null");
        }

        public async Task<ActionResult> TodaysTopColdestCities(CancellationToken cancellationToken)
        {
            var data = await _mediator.Send(new ListTodaysTopColdestCitiesRequest { PaginationArgs = new PaginationArgs(1, 3) }, cancellationToken);

            return PartialView(data);
        }
    }
}