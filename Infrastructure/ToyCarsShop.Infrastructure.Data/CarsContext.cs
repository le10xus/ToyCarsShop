using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyCarsShop.Domain.Core;

namespace ToyCarsShop.Infrastructure.Data
{
    public class CarsContext:DbContext
    {
        public CarsContext(DbContextOptions<CarsContext> options) : base(options)
        {
        }
        public DbSet<Car> Cars { get; set; }
        public DbSet<CarColor> CarColor { get; set; }
        public DbSet<CarType> CarType { get; set; }
    }
}
