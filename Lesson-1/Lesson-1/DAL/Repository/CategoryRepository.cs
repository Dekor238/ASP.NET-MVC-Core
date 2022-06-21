using Lesson_1.DAL.Interfaces;
using Lesson_1.Models;

namespace Lesson_1.DAL.Repository;

public class CategoryRepository : ICategory
{
    private readonly Catalog _catalog;

    public CategoryRepository(Catalog catalog)
    {
        _catalog = catalog;
    }

    public void Add(Category model)
    {
        if (model.Id!=0)
        {
            _catalog.Categories.TryAdd(model.Id, model);
        }
    }
    
    public IReadOnlyList<Category> GetAll()
    {
        var categories = _catalog.Categories.Values.ToList();
        return categories;
    }
    
    public void Delete(int id)
    {
        Category f;
        if (id!=0)
            _catalog.Categories.TryRemove(id, out f);
    }
    
    public void Edit(Category model)
    {
        Category oldmodel;
        if (model.Id != 0)
        {
            _catalog.Categories.TryGetValue(model.Id, out oldmodel);
            _catalog.Categories.TryUpdate(model.Id,  model, oldmodel);
        }
    }
}