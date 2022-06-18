using System.Collections.Concurrent;

namespace Lesson_1.Models;

public class Catalog : ILessons<Category>
{ 
    private ConcurrentDictionary<int, Category> Categories { get; set; } = new();
    
    public void Add(Category model)
    {
        if (model.Id!=0)
        {
            Categories.TryAdd(model.Id, model);
        }
    }
    
    public IReadOnlyList<Category> GetAll()
    {
        List<Category> f = new();
        if (true)
        {
            foreach (var c in Categories)
            {
                f.Add(c.Value);
            }
        }
        return f;
    }
    
    public void Delete(int id)
    {
        Category f;
        if (id!=0)
         Categories.TryRemove(id, out f);
    }
    
    public void Edit(Category model)
    {
        Category oldmodel;
        if (model.Id != 0)
        {
            Categories.TryGetValue(model.Id, out oldmodel);
            Categories.TryUpdate(model.Id,  model, oldmodel);
        }
    }
    
}