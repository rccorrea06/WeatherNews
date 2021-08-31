using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherNews.Domain.Models;

namespace WeatherNews.Domain.IServices
{
    public interface ICitiessWeatherService
    {
        public Task<Citysweather> City(string name);

        public Task<List<Citysweather>> Cities();

        public void SaveCity(Citysweather citysweather);
        

    }
}
