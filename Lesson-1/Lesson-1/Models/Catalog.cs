using System.Collections.Concurrent;
using Lesson_1.DAL.Interfaces;

namespace Lesson_1.Models;

public class Catalog : ICatalog
{
    public ConcurrentDictionary<int, Category> Categories { get; set; } = new();
}