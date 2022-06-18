using System.Collections.Concurrent;

namespace Lesson_1.Models;

public class Category : ILessons<Products>
{
    public int Id { get; set; }
    public string Name { get; set; }
    private ConcurrentDictionary<int, Products> Products { get; set; } = new();
    
    public void Add(Products model)
    {
        if (model.Id!=0)
        {
            Products.TryAdd(model.Id, model);
        }
    }
    
    public IReadOnlyList<Products> GetAll()
    {
        List<Products> f = new();
        if (true)
        {
            foreach (var c in Products)
            {
                f.Add(c.Value);
            }
        }
        return f;
    }
    
    public void Delete(int id)
    {
        Products f;
        if (id!=0)
            Products.TryRemove(id, out f);
    }
    
    public void Edit(Products model)
    {
        Products oldmodel;
        if (model.Id != 0)
        {
            Products.TryGetValue(model.Id, out oldmodel);
            Products.TryUpdate(model.Id,  model, oldmodel);
        }
    }
}