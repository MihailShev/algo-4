using System;
using System.Linq;
using System.Net.Sockets;

namespace algo_4
{
    public class SingleArray<T> : IArray<T>
    {
        protected T[] InternalArray;
        
        public SingleArray()
        {
            Size = 0;
            InternalArray = new T[Size];
        }

        private void Resize()
        {
            var newArray = new T[Size + 1];
            Array.Copy(InternalArray, newArray, Size);

            InternalArray = newArray;
            Size += 1;
        }

        public int Size { get; protected set; }

        public bool IsEmpty()
        {
            return Size == 0;
        }

        public virtual void Append(T item)
        {
            Resize();
            InternalArray[Size - 1] = item;
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
            var tmpArray = new T[Size - 1];

            var removed = InternalArray[index];
            Size--;
            
            Array.Copy(InternalArray, 0, tmpArray, 0, index);
            Array.Copy(InternalArray, index + 1, tmpArray, index, Size - index);
            
            InternalArray = tmpArray;

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