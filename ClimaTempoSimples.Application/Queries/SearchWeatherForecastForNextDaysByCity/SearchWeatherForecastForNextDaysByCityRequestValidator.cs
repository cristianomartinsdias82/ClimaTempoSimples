using FluentValidation;

namespace ClimaTempoSimples.Application.Queries.SearchWeatherForecastForNextDaysByCity
{
    public class SearchWeatherForecastForNextDaysByCityRequestValidator
        : AbstractValidator<SearchWeatherForecastForNextDaysByCityRequest>
    {
        public SearchWeatherForecastForNextDaysByCityRequestValidator()
        {
            RuleFor(x => x.City)
                .NotEmpty()
                .WithMessage("City parameter cannot be empty");

            RuleFor(x => x.DaysFromNow)
                .GreaterThan(0)
                .WithMessage("Days from now parameter must be a positive number");
        }
    }
}
