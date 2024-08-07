using RestaurantOrderSystem.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantOrderSystem.Services
{
    public class MockOrderService : IOrderService
    {
        public void PlaceOrder(List<Dish> dishes)
        {
            string xmlFile = System.IO.Path.Combine(Environment.CurrentDirectory, @"Data\Order.txt");
            if (!File.Exists(xmlFile)) { File.Create(xmlFile); }
            System.IO.File.WriteAllLines(xmlFile, dishes.AsEnumerable().Select(o => o.Name.ToString()).ToArray());
        }
    }
}
