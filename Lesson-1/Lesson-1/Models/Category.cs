namespace Lesson_1.Models;

public class Category : ILessons<Products>
{
    public int Id { get; set; }
    public string Name { get; set; }
    private List<Products> Products { get; set; } = new();
    
    private readonly Object _lock = new();
    
    public void Add(Products model)
    {
        lock (_lock)
        {
            if(model.Id!=0)
                Products.Add(model);
        }
    }
    
    public IReadOnlyList<Products> GetAll()
    {
        lock (_lock)
        {
            return Products;
        }
    }
    
    public void Delete(int id)
    {
        lock (_lock)
        {
            if (id!=0)
                Products.RemoveAll(c => c.Id == id);
        }
    }
    
    public void Edit(int id, string text)
    {
        lock (_lock)
        {
            if (id != 0)
            {
                Products.RemoveAll(f => f.Id == id);
                Products.Add(new() {Id = id, Name = text});
            }
        }
    }


}