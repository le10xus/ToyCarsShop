using System;

namespace ToyCarsShop.Domain.Core
{
    public enum CarType
    {
        Sedan,
        Jeep,
        Bus,
        Van
    }

    public enum Color
    {
        Black,
        White,
        Red,
        Blue,
        Gray
    }

    public class Car
    {
        public int Id { get; set; }
        public string ModelName { get; set; }
        public int Price { get; set; }
        public Color Color { get; set; }
        public CarType Type { get; set; }
    }
}
