using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToyCarsShop.Domain.Core
{
    public class Car
    {
        public int Id { get; set; }
        public string ModelName { get; set; }
        public int Price { get; set; }
        public int ColorId { get; set; }
        [ForeignKey("ColorId")]
        public CarColor Color { get; set; }
        public int TypeId { get; set; }
        [ForeignKey("TypeId")]
        public CarType Type { get; set; }
    }
}
