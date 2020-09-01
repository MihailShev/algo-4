using System;

namespace algo_4
{
    public class FactorArray<T> : SingleArray<T>
    {
        private readonly int _factor;
        private const int DefaultFactor = 2;

        private void Resize()
        {
            var newArray = new T[Size * _factor + 1];
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
        
        public FactorArray(int factor)
        {
            _factor = factor;
        }
        
        public FactorArray() : this(DefaultFactor)
        {
        }
    }
}