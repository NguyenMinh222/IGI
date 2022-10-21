using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WEB_053503_NGUYEN2.Data;
using WEB_053503_NGUYEN2.Entities;
using WEB_053503_NGUYEN2.Models;



namespace WEB_053503_NGUYEN2.Controllers
{
    public class ProductController : Controller
    {
        ApplicationDbContext _context;
        private int _pagesize;
        
        public ProductController(ApplicationDbContext context)
        {
            _context = context;
            _pagesize = 3;
            
        }
        public IActionResult Index(int? group, int pageNo = 1)
        {
            var guitarsFiltered = _context.Cars.Where(d => !group.HasValue || d.CarGroupId == group.Value);
            ViewData["Groups"] = _context.CarGroups;
            ViewData["CurrentGroup"] = group ?? 0;

            var model = ListViewModel<Car>.GetModel(guitarsFiltered, pageNo, _pagesize);
                return View(model);
        }
        
    }
}
