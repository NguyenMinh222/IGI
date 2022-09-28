using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace WEB_053503_NGUYEN2.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            
            ViewData["Text"] = "Лабораторная работа 2";
            ViewData["Lst"] = new SelectList(_listDemo, "ListItemValue","ListItemText");
            return View();
        }

        public string Hello()
        {
            return "Hi, everyone";
        }

       
        private List<ListDemo> _listDemo;

        public HomeController()
        {
            _listDemo = new List<ListDemo>
            {
                new ListDemo{ ListItemValue = 1, ListItemText="Объект 1" },
                new ListDemo{ ListItemValue = 2, ListItemText="Объект 2" },
                new ListDemo{ ListItemValue = 3, ListItemText="Объект 3" }
            };
        }
    }

    public class ListDemo
    {
        public int ListItemValue { get; set; }
        public string ListItemText { get; set; }
    }
}
