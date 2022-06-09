using Lesson_1.Models;
using Lesson_1.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Lesson_1.Controllers;

public class CatalogController : Controller
{
    private readonly CategoryRepository _categoryRepository;
    private static Catalog _catalog = new();
    private static Category _category = new();
    
    [HttpGet] // выводит весь список категорий при отображении страницы
    // public IActionResult Categories()
    // {
    //     return View(_categoryRepository.GetAll());
    // }
    
    // [HttpGet]
    // public IActionResult Products()
    // {
    //     return View(_category);
    // }
    
    [HttpPost] // добавляем новые категории в каталог
    public IActionResult Categories(Category model)
    {
        var result = _categoryRepository.Create(model);
        return View(result);
    }
    
    // [HttpPost]
    // public IActionResult Products(Products model)
    // {
    //    _category.ProductsList.Add(model);
    //     return View(_category);
    // }
}