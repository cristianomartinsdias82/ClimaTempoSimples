using FluentValidation;

namespace ClimaTempoSimples.Application.Queries.ListCitiesWithForecasts
{
    public class ListCitiesWithForecastsRequestValidator
        : AbstractValidator<ListCitiesWithForecastsRequest>
    {
        public ListCitiesWithForecastsRequestValidator()
        {
            RuleFor(x => x.PaginationArgs)
                .NotNull()
                .WithMessage("Pagination arguments cannot be empty");

            When(x => x.PaginationArgs != null,
                 () =>
                 {
                     RuleFor(x => x.PaginationArgs.PageNumber)
                        .GreaterThan(0)
                        .WithMessage("Page number parameter must be greater than 0");

                     RuleFor(x => x.PaginationArgs.PageSize)
                        .GreaterThan(0)
                        .WithMessage("Page size parameter must be greater than 0");
                 });
        }
    }
}
