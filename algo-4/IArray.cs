using System;

namespace algo_4
{
    public interface IArray<T>
    {
        int Size { get;}
        bool IsEmpty();
        void Append(T item);
        
        void AppendAt(T item, int index);
        T Get(int index);
        T Remove(int index);
    }
}