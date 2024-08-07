using RestaurantOrderSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantOrderSystem.Services
{
    public interface IOrderService
    {
        public void PlaceOrder(List<Dish> dishes);
    }
}
