using Lesson_1.Models;

namespace Lesson_1.Repository;

public class CategoryRepository : ICategory
{
    private List<Category> _categories = new List<Category>();
    public IEnumerable<Category> GetAll()
    {
        return _categories;
    }

    public Category Create(Category item)
    {
        if (_categories == null)
        {
            throw new ArgumentNullException("item");
        }
        _categories.Add(item);
        return item;
    }

    public bool Update(Category item)
    {
        if (item == null)
        {
            throw new ArgumentNullException("item");
        }
        int index = _categories.FindIndex(p => p.Id == item.Id);
        if (index == -1)
        {
            return false;
        }
        _categories.RemoveAt(index);
        _categories.Add(item);
        return true;
    }

    public void Delete(int id)
    {
        _categories.RemoveAll(i => i.Id == id);
    }
}