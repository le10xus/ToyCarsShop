using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyCarsShop.Domain.Core;

namespace ToyCarsShop.Infrastructure.Data
{
    public class DbInitializer
    {
        public static void Initialize(CarsContext context)
        {
            context.Database.EnsureCreated();

            if (context.Cars.Any())
            {
                return;
            }

            var cars = new Car[]
            {
                new Car{ Id = 1, Color = Color.Black, ModelName = "S300", Type = CarType.Sedan, Price = 2000 },
                new Car{ Id = 2, Color = Color.White, ModelName = "B250", Type = CarType.Bus, Price = 5000 },
                new Car{ Id = 3, Color = Color.Black, ModelName = "S300", Type = CarType.Sedan, Price = 2000 },
                new Car{ Id = 4, Color = Color.White, ModelName = "B450", Type = CarType.Bus, Price = 8000 },
                new Car{ Id = 5, Color = Color.Black, ModelName = "J300", Type = CarType.Jeep, Price = 2500 },
                new Car{ Id = 6, Color = Color.Blue,  ModelName = "J350", Type = CarType.Jeep, Price = 3000 },
                new Car{ Id = 7, Color = Color.Red,   ModelName = "S200", Type = CarType.Sedan, Price = 1200 }
            };
            foreach (var car in cars)
            {
                context.Cars.Add(car);
            }
            context.SaveChanges();
        }
    }
}
