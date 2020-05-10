using Microsoft.AspNetCore.Routing.Constraints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab1_web.Models
{
    public class CarItem
    {
        public long Id { get; set; }
        public string Brand { get; set; }
        public int Year { get; set; }
        public float Price { get; set; }
        public bool IsAvailable { get; set; }
    }
}
