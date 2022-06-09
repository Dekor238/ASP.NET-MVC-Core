namespace Lesson_1.Repository;

public interface IRepo<T> where T:class 
{
    IEnumerable<T> GetAll();
    T Create(T item);
    bool Update(T item);
    void Delete(int id);
}