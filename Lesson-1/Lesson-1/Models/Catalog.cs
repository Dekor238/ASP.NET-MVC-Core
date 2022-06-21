using System.Collections.Concurrent;
using Lesson_1.DAL.Interfaces;

namespace Lesson_1.Models;

public class Catalog
{ 
    internal ConcurrentDictionary<int, Category> Categories { get; set; } = new();
}