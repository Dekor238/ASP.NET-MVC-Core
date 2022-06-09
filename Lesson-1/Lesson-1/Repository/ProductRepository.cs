using Lesson_1.Models;

namespace Lesson_1.Repository;

public class ProductRepository : IProduct
{
    public IEnumerable<Products> GetAll()
    {
        throw new NotImplementedException();
    }

    public Products Create(Products item)
    {
        throw new NotImplementedException();
    }

    public bool Update(Products item)
    {
        throw new NotImplementedException();
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }
}