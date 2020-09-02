using System;
using System.Linq;
using System.Net.Sockets;

namespace algo_4
{
    public class SingleArray<T> : IArray<T>
    {
        protected T[] InternalArray;
        protected int Capacity = 0;

        public SingleArray()
        {
            Size = 0;
            Capacity = 1;
            InternalArray = new T[Capacity];
        }

        protected virtual void Resize()
        {
            Capacity++;
            var newArray = new T[Capacity];
            Array.Copy(InternalArray, newArray, Size);

            InternalArray = newArray;
        }

        public int Size { get; protected set; }

        public bool IsEmpty()
        {
            return Size == 0;
        }

        public virtual void Append(T item)
        {
            if (Size == Capacity)
                Resize();

            InternalArray[Size] = item;
            Size++;
        }

        public void AppendAt(T item, int index)
        {
            InternalArray[index] = item;
        }

        public T Get(int index)
        {
            return InternalArray[index];
        }

        public virtual T Remove(int index)
        {
            var removed = InternalArray[index];
            Size--;

            Array.Copy(InternalArray, 0, InternalArray, 0, index);
            Array.Copy(InternalArray, index + 1, InternalArray, index, Size - index);

            return removed;
        }

        public override string ToString()
        {
            var str = "[";

            for (var i = 0; i < Size; i++)
            {
                if (i != Size - 1)
                {
                    str += InternalArray[i] + ", ";
                }
                else
                {
                    str += InternalArray[i] + "]";
                }
            }

            return str;
        }
    }
}