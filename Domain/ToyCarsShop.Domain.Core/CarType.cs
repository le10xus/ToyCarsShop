using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyCarsShop.Domain.Core
{
    public enum BodyType
    {
        Sedan,
        Jeep,
        Bus,
        Van
    }

    public class CarType
    {
        [Key]
        public int TypeId { get; set; }
        public string TypeName { get; set; }
    }
}
