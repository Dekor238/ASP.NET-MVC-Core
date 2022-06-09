namespace Lesson_1.Models;

public class Catalog
{
    private List<Category> Categories { get; set; } = new();
    private readonly Object _lock = new();
    
    public List<Category> Add(Category model)
    {
        lock (_lock)
        {
            Categories.Add(model);
            return Categories;
        }
    }
    
    public List<Category> GetAll()
    {
        lock (_lock)
        {
            return Categories;
        }
    }

    public List<Category> Delete(int id)
    {
        lock (_lock)
        {
            Categories.RemoveAll(c => c.Id == id);
            return Categories;
        }
    }
    
}