using System.Collections.Concurrent;
using Lesson_1.Models;

namespace Lesson_1.DAL.Interfaces;

public interface ICatalog
{
    public ConcurrentDictionary<int, Category> Categories { get; set; }
}