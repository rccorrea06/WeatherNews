using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherNews.DTO
{
    public class DataCityDTO
    {
        public CoordDTO Coord { get; set; }
        public string Base { get; set; }
        public MainDTO Main { get; set; }
        public int Visibility { get; set; }
        public WindDTO Wind { get; set; }
        public CloudsDTO Clouds { get; set; }
        public int Dt { get; set; }
        public SysDTO Sys { get; set; }
        public int Id { get; set; }
        public string name { get; set; }
        public int Cod { get; set; }
    }
}
