using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherNews.Domain.IRepository;
using WeatherNews.Domain.Models;
using WeatherNews.Persistence.Context;

namespace WeatherNews.Persistence.Repositories
{
    public class CitiessWeatherRepository : ICitiessWeatherRepository
    {
        private readonly AplicationDbContext context;

        public CitiessWeatherRepository(AplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<List<Citysweather>> Cities()
        {
            return await context.Citiessweather.ToListAsync<Citysweather>();
        }

        public async Task<Citysweather> City(string name)
        {
            return await context.Citiessweather.Where(c => c.NameCity ==name).FirstOrDefaultAsync();
        }

        public void SaveCity(Citysweather citysweather)
        {
            context.Add(citysweather);
            context.SaveChangesAsync();
        }
    }
}
