using ClimaTempoSimples.Application.Common;
using ClimaTempoSimples.Application.Queries.ListCitiesWithForecasts;
using ClimaTempoSimples.Application.Queries.SearchWeatherForecastForNextDaysByCity;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ClimaTempoSimples.Controllers
{
    public class SearchWeatherForecastForNextDaysByCityController : Controller
    {
        private readonly IMediator _mediator;

        public SearchWeatherForecastForNextDaysByCityController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException($"{mediator} argument cannot be null");
        }

        public async Task<ActionResult> ListCitiesWithForecasts(CancellationToken cancellationToken)
        {
            var data = await _mediator.Send(new ListCitiesWithForecastsRequest { PaginationArgs = new PaginationArgs(1, int.MaxValue) }, cancellationToken);

            return PartialView(nameof(SearchWeatherForecastForNextDaysByCity), data);
        }

        public async Task<ActionResult> SearchWeatherForecastForNextDaysByCity(string city, CancellationToken cancellationToken)
        {
            var data = await _mediator.Send(new SearchWeatherForecastForNextDaysByCityRequest { City = city, DaysFromNow = 7 }, cancellationToken);

            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}