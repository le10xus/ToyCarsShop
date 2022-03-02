using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToyCarsShop.Domain.Core;
using ToyCarsShop.Domain.Interface;

namespace ToyCarsShop.Infrastructure.Data
{
    public class CarsRepository : ICarsRepository
    {
        private CarsContext dbContext;

        public CarsRepository(CarsContext carsContext)
        {
            dbContext = carsContext;
        }

        public void CreateCar(Car car)
        {
            dbContext.Cars.Add(car);
        }

        public void DeleteCar(int id)
        {
            var car = dbContext.Cars.Find(id);
            if (car != null)
            {
                dbContext.Cars.Remove(car);
            }
        }


        public IEnumerable<CarViewModel> GetAllCars()
        {
            var cars = dbContext.Cars;
            var carTypes = dbContext.CarType;
            var colors = dbContext.CarColor;
            var models = dbContext.CarModel;

            var viewModel = cars
                .Include(c => c.CarModel)
                .Include(c => c.Type)
                .Include(c => c.Color)
                .Select(x => new CarViewModel()
                {
                    Id = x.Id,
                    CarModel = x.CarModel.ModelName,
                    Price = x.Price,
                    Color = x.Color.ColorName,
                    Type = x.Type.TypeName
                });

            return viewModel;
        }

        public Car GetCar(int id)
        {
            return dbContext.Cars.Find(id);
        }

        public async Task<Car> UpdateCar(CarViewModel car)
        {
            var color = dbContext.CarColor.Where(x => x.ColorName == car.Color).FirstOrDefault();
            var model = dbContext.CarModel.Where(x => x.ModelName == car.CarModel).FirstOrDefault();
            var type = dbContext.CarType.Where(x => x.TypeName == car.Type).FirstOrDefault();

            var carModel = new Car()
            {
                Id = car.Id,
                Color = color,
                ColorId = color.ColorId,
                CarModel = model,
                ModelId = model.ModelId,
                Price = car.Price,
                Type = type,
                TypeId = type.TypeId
            };

            dbContext.Entry(carModel).State = EntityState.Modified;

            try
            {
                await dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!dbContext.Cars.Any(e => e.Id == car.Id))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }
            return carModel;
        }
    }
}
