using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherNews.Domain.IRepository;
using WeatherNews.Domain.IServices;
using WeatherNews.Domain.Models;

namespace WeatherNews.Services
{
    public class CitiessWeatherService : ICitiessWeatherService
    {

        private readonly ICitiessWeatherRepository weatherRepository;

        public CitiessWeatherService(ICitiessWeatherRepository WeatherRepository)
        {
            this.weatherRepository = WeatherRepository;
        }

        public async Task<List<Citysweather>> Cities()
        {
            return await weatherRepository.Cities();
        }

        public async Task<Citysweather> City(string name)
        {
            return await weatherRepository.City(name);
        }

        public async void SaveCity(Citysweather citysweather)
        {
            weatherRepository.SaveCity(citysweather);
        }
    }
}
