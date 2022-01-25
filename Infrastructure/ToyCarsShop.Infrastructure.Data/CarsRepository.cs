using System;
using System.Collections.Generic;
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

        public IEnumerable<Car> GetAllCars()
        {
            return dbContext.Cars;
        }

        public Car GetCar(int id)
        {
            return dbContext.Cars.Find(id);
        }

        public void UpdateCar(Car car)
        {
            dbContext.Entry(car).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }
    }
}
