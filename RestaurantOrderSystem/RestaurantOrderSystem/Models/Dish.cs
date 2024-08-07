using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantOrderSystem.Models
{
    public class Dish
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public string Comment { get; set; }
        public double Score { get; set; }
        public override string ToString()
        {
            return string.Format("{0},{1},{2},{3}", Name, Category, Comment, Score);
        }
    }
}
