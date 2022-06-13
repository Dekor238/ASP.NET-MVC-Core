using System.Collections;
using ASP;

namespace Lesson_1.Async;

public class ConcurrentList<T> : IEnumerable<T>
{
    private readonly Object _lock = new object();
    protected readonly List<T> InnerList = new List<T>();
    public int Count { get; private set; }

    public void Add(T item)
    {
        lock (_lock)
        {
            InnerList.Add(item);
            Count = InnerList.Count;
        }
    }
    
    public bool Delete(T item)
    {
        lock (_lock)
        {
            InnerList.Remove(item);
            Count = InnerList.Count;
            return true;
        }
    }

    public void Clear()
    {
        lock (_lock)
        {
            InnerList.Clear();
            Count = InnerList.Count;
        }
    }

    public T this[int i] => InnerList[i];

    public IEnumerator<T> GetEnumerator()
    {
        return new Enumerator<T>(this, Count);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

}

internal class Enumerator<T> : IEnumerator<T>
{
    private readonly ConcurrentList<T> _concurrentList;
    private int _index = -1;
    private readonly int _count;
  
    public Enumerator(ConcurrentList<T> concurrentList, int count)
    {
        _concurrentList = concurrentList;
        _count = count;
    }
  
    public bool MoveNext()
    {
        if (_index == _count - 1)
        {
            Reset();
            return false;
        }
        _index++;
        return true;
    }
  
    public void Reset()
    {
        _index = -1;
    }
  
    public T Current => _concurrentList[_index];
  
    object IEnumerator.Current => Current;
  
    public void Dispose()
    {
    }
}