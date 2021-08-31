using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherNews.Domain.Models
{
    public class Citysweather
    {
        public int Id { get; set; }

        [Required]
        [Column(TypeName ="varchar(225)")]
        public string NameCity { get; set; }

        [Required]
        [Column(TypeName = "varchar(MAX)")]
        public string DataJson { get; set; }

    }
}
