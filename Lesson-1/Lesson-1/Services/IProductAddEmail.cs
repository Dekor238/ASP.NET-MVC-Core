namespace Lesson_1.Services;

public interface IProductAddEmail<T>
{
    public void Add(T product);
    // public IReadOnlyList<T> GetAll();
    // public void Delete(int id);
    // public void Edit(T model);
}