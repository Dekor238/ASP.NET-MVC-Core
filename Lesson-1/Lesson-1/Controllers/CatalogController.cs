using Lesson_1.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lesson_1.Controllers;

public class CatalogController : Controller
{
    private static Catalog _catalog = new();
    // private static Category _category = new();
    
    [HttpGet] // выводит весь список категорий при отображении страницы
    public IActionResult Categories()
    {
        return View(_catalog.GetAll());
    }

    public IActionResult Add([FromForm] Category model)
    {
        _catalog.Add(model);
        return View("Add");
    }

    public IActionResult Delete([FromForm] int id2)
    {
        _catalog.Delete(id2);
        return View("Delete");
    }

    public IActionResult Edit([FromForm] int id, string name)
    {
        _catalog.Edit(id,name);
        return View("Edit");
    }
}