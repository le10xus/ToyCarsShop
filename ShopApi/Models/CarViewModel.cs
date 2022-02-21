using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopApi.Models
{
    public class CarViewModel
    {
        public int Id { get; set; }
        public string CarModel { get; set; }
        public int Price { get; set; }
        public int ColorId { get; set; }
        public int TypeId { get; set; }
    }
}
