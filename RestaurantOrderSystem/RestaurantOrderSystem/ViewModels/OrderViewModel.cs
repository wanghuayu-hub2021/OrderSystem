using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Prism.Mvvm;
using Prism.Regions;
using RestaurantOrderSystem.Command;
using RestaurantOrderSystem.Models;
using RestaurantOrderSystem.Services;

namespace RestaurantOrderSystem.ViewModels
{
    public class OrderViewModel : BindableBase
    {

        private int count;
        public int Count
        {
            get { return count; }
            set
            {
                SetProperty(ref count, value);
            }
        }

        private List<DishMenuItemViewModel> menuItem;

        public List<DishMenuItemViewModel> MenuItem
        {
            get { return menuItem; }
            set
            {
                SetProperty(ref menuItem, value);
            }
        }

        private Restaurant myRestaurant;

        public Restaurant MyRestaurant
        {
            get { return myRestaurant; }
            set
            {
                SetProperty(ref myRestaurant, value);
            }
        }

        public OrderViewModel()
        {
            orderService = new MockOrderService();
            xmlDataService = new XmlDataService();
            LoadRestaurant();
            LoadMenuData();
            Count = 0;
        }

        private void LoadRestaurant()
        {
            Restaurant restaurant = new Restaurant();
            restaurant.Name = "JokerRestaurant";
            restaurant.Address = "上海世纪汇";
            restaurant.Phone = "024-25978888";
            this.MyRestaurant = restaurant;
        }

        private MockOrderService orderService;
        private XmlDataService xmlDataService;
        private void LoadMenuData()
        {
            List<Dish> dishes = xmlDataService.GetDishes();
            List<DishMenuItemViewModel> dishMenuList = new List<DishMenuItemViewModel>();
            foreach (Dish dish in dishes)
            {
                DishMenuItemViewModel dishMenu = new DishMenuItemViewModel();
                dishMenu.Dish = dish;
                dishMenu.IsSelected = false;
                dishMenuList.Add(dishMenu);
            }
            this.MenuItem = dishMenuList;
        }

        private RelayCommand placeOrderCommand;
        public RelayCommand PlaceOrderCommand
        {
            get
            {
                if (placeOrderCommand == null)
                    placeOrderCommand = new RelayCommand(PlaceOrderCommandExecute);
                return placeOrderCommand;
            }
            set { placeOrderCommand = value; }
        }

        private void PlaceOrderCommandExecute(object param)
        {
            var orderMenu = this.MenuItem.Where(o => o.IsSelected == true).Select(o => o.Dish).ToList();
            orderService.PlaceOrder(orderMenu);
            MessageBox.Show("下单成功!");
        }

        private RelayCommand selectMenuItemCommand;
        public RelayCommand SelectMenuItemCommand
        {
            get
            {
                if (selectMenuItemCommand == null)
                    selectMenuItemCommand = new RelayCommand(SelectMenuItemCommandExecute);
                return selectMenuItemCommand;
            }
            set { selectMenuItemCommand = value; }
        }

        private void SelectMenuItemCommandExecute(object param)
        {
            this.Count = this.MenuItem.Where(o => o.IsSelected == true).Count();
        }

    }
}
