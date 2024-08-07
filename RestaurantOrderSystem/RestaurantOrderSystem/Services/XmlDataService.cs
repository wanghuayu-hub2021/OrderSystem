using RestaurantOrderSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Collections.Generic;

namespace RestaurantOrderSystem.Services
{
    internal class XmlDataService : IDataService
    {
        public List<Dish> GetDishes()
        {
            List<Dish> disheList = new List<Dish>();
            string xmlFile = System.IO.Path.Combine(Environment.CurrentDirectory, @"Data\Data.xml");
            XDocument xmlDoc = XDocument.Load(xmlFile);
            var dishes = xmlDoc.Descendants("Dish");
            Dish dish = null;
            foreach (var item in dishes)
            {
                dish = new Dish();
                dish.Name = item.Element("Name")?.Value;
                dish.Category = item.Element("Category")?.Value;
                dish.Comment = item.Element("Comment")?.Value;
                dish.Score = Convert.ToDouble(item.Element("Score")?.Value);
                disheList.Add(dish);
            }
            return disheList;
        }
    }
}
