namespace ClimaTempoSimples.Application.Queries.ListTodaysTopColdestCities
{
    public class ListTodaysTopColdestCitiesDto
    {
        public string City { get; set; }
        public string State { get; set; }
        public decimal MaxTemperature { get; set; }
    }
}
