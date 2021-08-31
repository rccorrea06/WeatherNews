using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using WeatherNews.Domain.IServices;
using WeatherNews.Domain.Models;
using WeatherNews.DTO;

namespace WeatherNews.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherNewsController : ControllerBase
    {
        private const string _uri = "https://samples.openweathermap.org/data/2.5/weather";
        private readonly ICitiessWeatherService weatherService;
        public WeatherNewsController(ICitiessWeatherService weatherService)
        {
            this.weatherService = weatherService;
        }

        //GET: api/<WeatherNews>
        [HttpPost()]
        public async Task<IActionResult> Post(string namecity)
        {
            Citysweather citysweather = await weatherService.City(namecity);

            if (citysweather != null)
            {
                return Ok(citysweather);
            }

            UriBuilder builder = new UriBuilder(_uri);
            builder.Query = $"q={namecity}&appid=b754be65ba407eda65f30659d457c0fc";

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));            

            var stringTask = client.GetStringAsync(builder.Uri).Result;

            citysweather = new Citysweather()
            {
                NameCity = namecity,
                DataJson = stringTask
            };

            weatherService.SaveCity(citysweather);

            return Ok(stringTask);

        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var citiess = await weatherService.Cities();

            List<ResultCitiessWaetherDTO> listCitiesDTO = new List<ResultCitiessWaetherDTO>();

            foreach (var item in citiess)
            {
                listCitiesDTO.Add(
                        new ResultCitiessWaetherDTO()
                        {
                            city = item.NameCity,
                            info = JsonConvert.DeserializeObject<DataCityDTO>(item.DataJson)
                        }
                    ); ; ;
            }
            string result = JsonConvert.SerializeObject(listCitiesDTO);
            return Ok("{\"history\":" + result +"}");
        }

    }
}
