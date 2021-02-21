using MediatR;

namespace ClimaTempoSimples.Application.Queries.SearchWeatherForecastForNextDaysByCity
{
    public class SearchWeatherForecastForNextDaysByCityRequest : IRequest<SearchWeatherForecastForNextDaysByCityResponse>
    {
        public string City { get; set; }
        public int DaysFromNow { get; set; }
    }
}
