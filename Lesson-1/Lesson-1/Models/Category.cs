namespace Lesson_1.Models;

public class Category
{
    public int Id { get; set; }
    public string  Name { get; set; }

    public List<Products> ProductsList { get; set; } = new();
}