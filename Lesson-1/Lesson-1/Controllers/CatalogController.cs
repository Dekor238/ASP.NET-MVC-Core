using Lesson_1.DAL.Interfaces;
using Lesson_1.DAL.Repository;
using Lesson_1.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lesson_1.Controllers;

public class CatalogController : Controller
{
    private readonly ICategory _category;
    private readonly ILogger<CatalogController> _logger;

    public CatalogController(ICategory category, ILogger<CatalogController> logger)
    {
        _category = category;
        _logger = logger;
    }

    public IActionResult Categories()
    {
        _logger.LogInformation("Return Catalog list");
        return View(_category.GetAll());
    }

    public IActionResult Add([FromForm] Category model)
    {
        try
        {
            _category.Add(model);
            _logger.LogInformation("Added new Category : {@mode}", model);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Failed to add new Category to Catalog");
        }
        return View("Add");
    }

    public IActionResult Delete([FromForm] int id2)
    {
        try
        {
            _category.Delete(id2);
            _logger.LogInformation("Deleted Category with ID: {id}", id2);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Failed to delete Category from Catalog");
        }
        return View("Delete");
    }

    public IActionResult Edit([FromForm] Category model)
    {
        try
        {
            _category.Edit(model);
            _logger.LogInformation("Update Category with ID: {id} with new data {@model}", model.Id, model);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Failed to update Category in Catalog");
        }
        return View("Edit");
    }
}