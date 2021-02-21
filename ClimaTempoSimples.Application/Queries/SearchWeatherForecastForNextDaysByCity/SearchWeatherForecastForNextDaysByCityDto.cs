using ClimaTempoSimples.Application.Utilities;
using System;

namespace ClimaTempoSimples.Application.Queries.SearchWeatherForecastForNextDaysByCity
{
    public class SearchWeatherForecastForNextDaysByCityDto
    {
        public DateTime Date { get; set; }
        public string FormattedDate { get { return Date.ToShortDateString(); } }
        public string DayOfWeek { get { return DateTimeUtilities.GetWeekDayPortugueseTranslation(Date.DayOfWeek); } }
        public string WeatherForecast { get; set; }
        public decimal MinTemperature { get; set; }
        public decimal MaxTemperature { get; set; }
    }
}
