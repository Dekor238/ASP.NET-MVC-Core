using System.Collections.Concurrent;
using Lesson_1.DAL.Interfaces;

namespace Lesson_1.Models;

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; }
    internal ConcurrentDictionary<int, Products> Products { get; set; } = new();
    
}