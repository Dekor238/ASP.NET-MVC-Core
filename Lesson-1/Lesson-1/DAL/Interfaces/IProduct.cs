using Lesson_1.Models;

namespace Lesson_1.DAL.Interfaces;

public interface IProduct
{
    public void Add(Products model);
    public IReadOnlyList<Products> GetAll();
    public void Delete(int id);
    public void Edit(Products model);
}