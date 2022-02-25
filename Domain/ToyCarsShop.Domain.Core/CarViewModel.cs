using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyCarsShop.Domain.Core
{
    public class CarViewModel
    {
        public int Id { get; set; }
        public string CarModel { get; set; }
        public int Price { get; set; }
        public string Color { get; set; }
        public string Type { get; set; }
    }
}
