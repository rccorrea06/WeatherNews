using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherNews.Domain.Models;

namespace WeatherNews.Persistence.Context
{
    public class AplicationDbContext : DbContext
    {
        public DbSet<Citysweather> Citiessweather { get; set; }

        public AplicationDbContext(DbContextOptions<AplicationDbContext> options) : base(options)
        {

        }
    }
}
