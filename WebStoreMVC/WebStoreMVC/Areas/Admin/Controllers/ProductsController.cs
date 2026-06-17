using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebStoreMVC.Areas.Admin.Models.Product;
using WebStoreMVC.Constants;
using WebStoreMVC.Data;

namespace WebStoreMVC.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = $"{Roles.Admin}")]
public class ProductsController(
    MyContextShopMVC myContext
    ) : Controller
{
    public IActionResult Index()
    {
        ViewBag.Title = "Продукти";
        var model = myContext.Products.Select(x => 
            new ProductItemViewModel
            {
                CategoryName = x.Category.Name,
                Images = x.ProductImages
                    .OrderBy(x=>x.Priority)
                    .Select(x=>x.Name)
                    .ToList(),
                Name = x.Name,
                Description = x.Description,
            }).ToList();
        return View(model);
    }

    [HttpGet]
    public IActionResult Create()
    {
        ViewBag.Title = "Створити продукт";
        ViewBag.Categories = myContext.Categories.ToList();
        return View();
    }
}
