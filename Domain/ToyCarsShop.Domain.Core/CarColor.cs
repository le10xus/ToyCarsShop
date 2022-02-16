using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyCarsShop.Domain.Core
{
    public enum Color
    {
        Black,
        White,
        Red,
        Blue,
        Gray
    }

    public class CarColor
    {
        [Key]
        public int ColorId { get; set; }
        public string ColorName { get; set; }
    }
}
