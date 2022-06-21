using Lesson_1.DAL.Repository;
using Lesson_1.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lesson_1.Controllers;

public class CatalogController : Controller
{
    private readonly CategoryRepository _category;

    public CatalogController(CategoryRepository category)
    {
        _category = category;
    }

    public IActionResult Categories()
    {
        return View(_category.GetAll());
    }

    public IActionResult Add([FromForm] Category model)
    {
        _category.Add(model);
        return View("Add");
    }

    public IActionResult Delete([FromForm] int id2)
    {
        _category.Delete(id2);
        return View("Delete");
    }

    public IActionResult Edit([FromForm] Category model)
    {
        _category.Edit(model);
        return View("Edit");
    }
}