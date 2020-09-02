using System;

namespace algo_4
{
    public class FactorArray<T> : SingleArray<T>
    {
        private readonly int _factor;
        private const int DefaultFactor = 2;

        protected override void Resize()
        {
            Capacity *= _factor;
            var newArray = new T[Capacity];
            Array.Copy(InternalArray, newArray, Size);
            InternalArray = newArray;
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