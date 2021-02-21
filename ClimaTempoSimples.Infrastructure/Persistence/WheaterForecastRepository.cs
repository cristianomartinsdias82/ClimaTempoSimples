using ClimaTempoSimples.Application.Common;
using ClimaTempoSimples.Application.Queries.Interfaces;
using ClimaTempoSimples.Application.Queries.ListCitiesWithForecasts;
using ClimaTempoSimples.Application.Queries.ListTodaysTopColdestCities;
using ClimaTempoSimples.Application.Queries.ListTodaysTopHottestCities;
using ClimaTempoSimples.Application.Queries.SearchWeatherForecastForNextDaysByCity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ClimaTempoSimples.Infrastructure.Persistence
{
    public class WheaterForecastRepository : IWeatherForecastRepository
    {
        private readonly ClimaTempoEntities _dbContext;

        public WheaterForecastRepository(ClimaTempoEntities dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException($"{dbContext} argument cannot be null");
        }

        public async Task<IEnumerable<ListTodaysTopHottestCitiesDto>> FetchTodaysTopHottestCitiesAsync(PaginationArgs paginationArgs, CancellationToken cancellationToken)
        {
            var data = (from pc in _dbContext.PrevisaoClima
                                             .Include(x => x.Cidade)
                                             .Include(x => x.Cidade.Estado)
                        join e in _dbContext.Estado on pc.Cidade.EstadoId equals e.Id
                        where DbFunctions.TruncateTime(pc.DataPrevisao) == DbFunctions.TruncateTime(DateTime.Now)
                        orderby pc.TemperaturaMaxima descending, pc.Cidade.Nome, e.UF
                         select new ListTodaysTopHottestCitiesDto
                         {
                             City = pc.Cidade.Nome,
                             State = e.UF,
                             MaxTemperature = pc.TemperaturaMaxima ?? 0M
                         })
                        .AsNoTracking()
                        .ToPaginatedListAsync(paginationArgs, cancellationToken);

            return await data;
        }

        public async Task<IEnumerable<ListTodaysTopColdestCitiesDto>> FetchTodaysTopColdestCitiesAsync(PaginationArgs paginationArgs, CancellationToken cancellationToken)
        {
            var data = (from pc in _dbContext.PrevisaoClima
                                             .Include(x => x.Cidade)
                                             .Include(x => x.Cidade.Estado)
                        join e in _dbContext.Estado on pc.Cidade.EstadoId equals e.Id
                        where DbFunctions.TruncateTime(pc.DataPrevisao) == DbFunctions.TruncateTime(DateTime.Now)
                        orderby pc.TemperaturaMinima, pc.Cidade.Nome, e.UF
                        select new ListTodaysTopColdestCitiesDto
                        {
                            City = pc.Cidade.Nome,
                            State = e.UF,
                            MaxTemperature = pc.TemperaturaMinima ?? 0M
                        })
                        .AsNoTracking()
                        .ToPaginatedListAsync(paginationArgs, cancellationToken);

            return await data;
        }

        public async Task<IEnumerable<ListCitiesWithForecastsDto>> ListCitiesWithForecastsAsync(PaginationArgs paginationArgs, CancellationToken cancellationToken)
        {
            var data = (from c in _dbContext.Cidade
                        join e in _dbContext.Estado on c.EstadoId equals e.Id
                        orderby c.Estado.UF, c.Nome
                        select new ListCitiesWithForecastsDto
                              {
                                  State = e.UF,
                                  City = c.Nome
                              })
                        .AsNoTracking()
                        .ToPaginatedListAsync(paginationArgs, cancellationToken);
            
            return await data;
        }

        public async Task<IEnumerable<SearchWeatherForecastForNextDaysByCityDto>> SearchWeatherForecastForNextDaysByCityAsync(string city, int daysFromNow, CancellationToken cancellationToken)
        {
            var now = DateTime.Now.Date;
            var futureDate = now.AddDays(Math.Abs(daysFromNow));
            var data = (from pc in _dbContext.PrevisaoClima
                                             .Include(x => x.Cidade)
                        where DbFunctions.TruncateTime(pc.DataPrevisao) >= now &&
                              DbFunctions.TruncateTime(pc.DataPrevisao) <= futureDate &&
                              city.Trim().ToUpper() == pc.Cidade.Nome.Trim().ToUpper()
                        orderby pc.DataPrevisao
                        select new SearchWeatherForecastForNextDaysByCityDto
                        {
                            Date = pc.DataPrevisao,
                            WeatherForecast = pc.Clima,
                            MinTemperature = pc.TemperaturaMinima ?? 0M,
                            MaxTemperature = pc.TemperaturaMaxima ?? 0M
                        })
                        .AsNoTracking()
                        .ToPaginatedList(new PaginationArgs(1, daysFromNow));

            return await Task.FromResult(data);
        }
    }
}
