using System;

namespace algo_4
{
    public class VectorArray<T> : SingleArray<T>
    {
        private readonly int _vector;
        private const int DefaultVectorSize = 10;

        protected override void Resize()
        {
            Capacity += _vector;
            var newArray = new T[Capacity];
            Array.Copy(InternalArray, newArray, Size);
            InternalArray = newArray;
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