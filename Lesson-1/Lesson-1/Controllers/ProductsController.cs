using Lesson_1.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lesson_1.Controllers;

public class ProductsController : Controller
{
    private static Category _category = new();

    // GET
    // Products
    public IActionResult Products()
    {
        return View(_category.GetAll());
    }

    public IActionResult AddP([FromForm] Products model)
    {
        _category.Add(model);
        return View("Add");
    }

    public IActionResult DeleteP([FromForm] int id2)
    {
        _category.Delete(id2);
        return View("Delete");
    }

    public IActionResult EditP([FromForm] int id, string name)
    {
        _category.Edit(id,name);
        return View("Edit");
    }
}