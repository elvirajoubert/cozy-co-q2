using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CozyCo.Models;
using Microsoft.AspNetCore.Mvc;

namespace CozyCo.WebUI.Controllers
{
    public class PropertyController : Controller
    {
        private List<Property> Properties = new List<Property>
        {
            new Property { Id = 1, Address = "123 Main Street", City = "Austin", Zipcode = "78654" },
            new Property { Id = 2, Address = "87887 Main Street", City = "Pflugerville", Zipcode = "78660"},
        };

        // property/index
        public IActionResult Index()
        {
            return View(Properties);
        }

        // GET property/add
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Property newProperty) // -> receive data from a HTML form
        {
            Properties.Add(newProperty);

            return View(nameof(Index), Properties);
        }

        public IActionResult Detail(int id) // -> get id from URL
        {
            var property = Properties.Single(p => p.Id == id);
            
            return View();
        }

        public IActionResult Delete(int id)
        {
            var property = Properties.Single(p => p.Id == id);

            Properties.Remove(property);

            return View(nameof(Index), Properties);
        }
    }
}