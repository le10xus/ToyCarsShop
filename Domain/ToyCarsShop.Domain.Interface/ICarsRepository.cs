using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToyCarsShop.Domain.Core;

namespace ToyCarsShop.Domain.Interface
{
    public interface ICarsRepository
    {
        IEnumerable<CarViewModel> GetAllCars();
        Car GetCar(int id);
        void CreateCar(Car car);
        void DeleteCar(int id);
        Task<Car> UpdateCar(CarViewModel car);
    }
}
