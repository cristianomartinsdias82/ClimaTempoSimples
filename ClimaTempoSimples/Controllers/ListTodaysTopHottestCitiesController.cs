using ClimaTempoSimples.Application.Common;
using ClimaTempoSimples.Application.Queries.ListTodaysTopHottestCities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ClimaTempoSimples.Controllers
{
    public class ListTodaysTopHottestCitiesController : Controller
    {
        private readonly IMediator _mediator;

        public ListTodaysTopHottestCitiesController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException($"{mediator} argument cannot be null");
        }

        public async Task<ActionResult> TodaysTopHottestCities(CancellationToken cancellationToken)
        {
            var data = await _mediator.Send(new ListTodaysTopHottestCitiesRequest { PaginationArgs = new PaginationArgs(1, 3) }, cancellationToken);

            return PartialView(data);
        }
    }
}