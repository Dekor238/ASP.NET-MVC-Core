namespace Lesson_1.Models;

public interface ILessons<T> where T: class
{
    public void Add(T model);
    public IReadOnlyList<T> GetAll();
    public void Delete(int id);
    public void Edit(T model);
}