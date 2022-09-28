using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using WEB_053503_NGUYEN2.Models;

namespace WEB_053503_NGUYEN2.Components
{
    public class MenuViewComponent: ViewComponent
    {
      private List<MenuItem> _menuItems = new List<MenuItem>
      { 
          new MenuItem { Controller = "Home", Action="Index", Text="Lab 2"},
          new MenuItem { Controller = "Product", Action="Index", Text="Каталог"},
          new MenuItem { IsPage = true, Action="Admin", Page="/Index",Text="Администрирование"},
      };

        public IViewComponentResult Invoke() {

            //текущий пункт меню
            var controller = ViewContext.RouteData.Values["controller"];
            //var page = ViewContext.RouteData.Values["page"];
            var area = ViewContext.RouteData.Values["area"];

            //проверка : совпадает ли имя контроллера и имя области с текущим меню
            foreach (var menuitem in _menuItems)
            {
                var _matchController = controller?.Equals(menuitem.Controller) ?? false;
                var _matchArea = area?.Equals(menuitem.Area) ?? false;

                if (_matchController || _matchArea)
                {
                    menuitem.Active = "active";
                }
            }

            return View(_menuItems);
        }
    }
}
