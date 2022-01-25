using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToyCarsShop.Domain.Core;
using ToyCarsShop.Domain.Interface;

namespace ToyCarsShop.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarsController : ControllerBase
    {
        ICarsRepository _carsRepository;

        public CarsController(ICarsRepository carsRepository)
        {
            _carsRepository = carsRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Car>> Get()
        {
            return _carsRepository.GetAllCars().ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Car> Get(int id)
        {
            return _carsRepository.GetCar(id);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _carsRepository.DeleteCar(id);
            return Ok();
        }

        [HttpPut]
        public ActionResult Put(Car car)
        {
            if (car == null)
            {
                return BadRequest();
            }
            _carsRepository.CreateCar(car);
            return Ok();
        }
    }
}
