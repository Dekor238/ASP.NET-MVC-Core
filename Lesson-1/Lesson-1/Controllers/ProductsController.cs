using Lesson_1.DAL.Repository;
using Lesson_1.Models;
using Lesson_1.Services;
using Microsoft.AspNetCore.Mvc;

namespace Lesson_1.Controllers;

public class ProductsController : Controller
{
    private readonly ProductsRepository _productsRepository;
    private readonly IProductAddEmail<Products> _product;

    // GET
    // Products
    public ProductsController(IProductAddEmail<Products> product, ProductsRepository productsRepository)
    {
        _product = product;
        _productsRepository = productsRepository;
    }

    public IActionResult Products()
    {
        return View(_productsRepository.GetAll());
    }

    public IActionResult AddP([FromForm] Products model)
    {
        //_category.Add(model);
        _product.Add(model);
        return View("Add");
    }

    public IActionResult DeleteP([FromForm] int id2)
    {
        _productsRepository.Delete(id2);
        return View("Delete");
    }

    public IActionResult EditP([FromForm] Products model)
    {
        _productsRepository.Edit(model);
        return View("Edit");
    }
}