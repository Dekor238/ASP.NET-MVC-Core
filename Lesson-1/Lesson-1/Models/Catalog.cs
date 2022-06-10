namespace Lesson_1.Models;

public class Catalog : ILessons<Category>
{
    private List<Category> Categories { get; set; } = new();
    private readonly Object _lock = new();
    
    public void Add(Category model)
    {
        lock (_lock)
        {
            if(model.Id!=0)
                Categories.Add(model);
        }
    }
    
    public List<Category> GetAll()
    {
        lock (_lock)
        {
            return Categories;
        }
    }
    
    public void Delete(int id)
    {
        lock (_lock)
        {
            if (id!=0)
                Categories.RemoveAll(c => c.Id == id);
        }
    }
    
    public void Edit(int id, string text)
    {
        lock (_lock)
        {
            if (id != 0)
            {
                Categories.RemoveAll(f => f.Id == id);
                Categories.Add(new() {Id = id, Name = text});
            }
        }
    }
    
}