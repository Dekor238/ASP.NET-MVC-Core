using Lesson_1.DAL.Interfaces;
using Lesson_1.DAL.Repository;
using Lesson_1.Models;
using Lesson_1.Services;
using Microsoft.AspNetCore.Mvc;

namespace Lesson_1.Controllers;

public class ProductsController : Controller
{
    private readonly IProduct _productsRepository;
    private readonly IProductAddEmail _product;
    private readonly ILogger<CatalogController> _logger;

    // GET
    // Products
    public ProductsController(IProductAddEmail product, IProduct productsRepository, ILogger<CatalogController> logger)
    {
        _product = product;
        _productsRepository = productsRepository;
        _logger = logger;
    }

    public IActionResult Products()
    {
        _logger.LogInformation("Return Product list");
        return View(_productsRepository.GetAll());
    }

    public IActionResult AddP([FromForm] Products model)
    {
        try
        {
            _product.Add(model);
            _logger.LogInformation("Added new Product to Category : {@mode}", model);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Failed to add new Product to Category");
        }
        return View("Add");
    }

    public IActionResult DeleteP([FromForm] int id2)
    {
        try
        {
            _productsRepository.Delete(id2);
            _logger.LogInformation("Deleted Product with ID : {id}", id2);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Failed to delete Product from Category");
        }
        
        return View("Delete");
    }

    public IActionResult EditP([FromForm] Products model)
    {
        try
        {
            _productsRepository.Edit(model);
            _logger.LogInformation("Update Product with ID : {id} with new data : {@model}", model.Id, model);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Failed to update Product in Category");
        }

        return View("Edit");
    }
}