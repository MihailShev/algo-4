using System;

namespace algo_4
{
    public class VectorArray<T> : SingleArray<T>
    {
        private readonly int _vector;
        private const int DefaultVectorSize = 10;

        private void Resize()
        {
            var newArray = new T[Size + _vector];
            Array.Copy(InternalArray, newArray, Size);
            InternalArray = newArray;
        }
        
        public override void Append(T item)
        {
            
            if (Size == InternalArray.Length)
                Resize();
            
            InternalArray[Size] = item;
            Size++;
        }
        
        public VectorArray(int vector)
        {
            _vector = vector;
        }

        public VectorArray() : this(DefaultVectorSize)
        {
           
        }
    }
}