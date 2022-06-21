using Lesson_1.Models;

namespace Lesson_1.DAL.Interfaces;

public interface ICategory
{
    public void Add(Category model);
    public IReadOnlyList<Category> GetAll();
    public void Delete(int id);
    public void Edit(Category model);
}