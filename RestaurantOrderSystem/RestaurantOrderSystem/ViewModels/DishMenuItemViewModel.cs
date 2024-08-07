using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;
using RestaurantOrderSystem.Models;


namespace RestaurantOrderSystem.ViewModels
{
    public class DishMenuItemViewModel :BindableBase
    {
        public Dish Dish {  get; set; }

        private bool isSelected;

        public bool IsSelected
        {
            get { return isSelected; }
            set { SetProperty(ref isSelected, value); }
        }
    }
}
