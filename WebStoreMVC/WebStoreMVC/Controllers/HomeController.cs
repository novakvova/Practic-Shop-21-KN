using Microsoft.AspNetCore.Mvc;
using WebStoreMVC.Data;
using WebStoreMVC.Mapper;

namespace WebStoreMVC.Controllers
{
    public class HomeController(MyContextShopMVC myContext, CategoryMapper categoryMapper) : Controller
    {
        public IActionResult Index()
        {
            var items = myContext.Categories.ToList();
            var modal = categoryMapper.CategoriesToCategoryItems(items);
            return View(modal);
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
