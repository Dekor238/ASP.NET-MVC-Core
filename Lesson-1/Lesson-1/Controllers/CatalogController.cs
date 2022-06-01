using Lesson_1.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lesson_1.Controllers;

public class CatalogController : Controller
{
    private static Catalog _catalog = new();
    private static Category _category = new();
    
    [HttpGet] // выводит весь список категорий при отображении страницы
    public IActionResult Categories()
    {
        return View(_catalog);
    }
    
    [HttpGet]
    public IActionResult Products()
    {
        return View(_category);
    }
    
    [HttpPost] // добавляем новые категории в каталог
    public IActionResult Categories(Category model)
    {
        _catalog.Categories.Add(model);
        return View(_catalog);
    }
    
    [HttpPost]
    public IActionResult Products(Products model)
    {
       _category.ProductsList.Add(model);
        return View(_category);
    }
}