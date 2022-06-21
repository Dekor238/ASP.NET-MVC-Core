using Lesson_1.DAL.Interfaces;
using Lesson_1.Models;

namespace Lesson_1.DAL.Repository;

public class ProductsRepository : IProduct
{
    private readonly Category _category;

    public ProductsRepository(Category category)
    {
        _category = category;
    }

    public void Add(Products model)
    {
        if (model.Id!=0)
        {
            _category.Products.TryAdd(model.Id, model);
        }
    }
    
    public IReadOnlyList<Products> GetAll()
    {
        var product = _category.Products.Values.ToList();
        return product;
    }
    
    public void Delete(int id)
    {
        Products f;
        if (id!=0)
            _category.Products.TryRemove(id, out f);
    }
    
    public void Edit(Products model)
    {
        Products oldmodel;
        if (model.Id != 0)
        {
            _category.Products.TryGetValue(model.Id, out oldmodel);
            _category.Products.TryUpdate(model.Id,  model, oldmodel);
        }
    }
}