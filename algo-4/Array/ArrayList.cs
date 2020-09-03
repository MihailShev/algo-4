namespace algo_4
{
    public class ArrayList<T> : IArray<T>
    {
        private readonly System.Collections.ArrayList _internalArray;
        
        public ArrayList()
        {
            _internalArray = new System.Collections.ArrayList();
        }

        public int Size => _internalArray.Count;

        public bool IsEmpty()
        {
            return Size == 0;
        }

        public void Append(T item)
        {
            _internalArray.Add(item);
        }

        public void AppendAt(T item, int index)
        {
            _internalArray.Insert(index, item);
        }

        public T Get(int index)
        {
            return (T)_internalArray[index];
        }

        public T Remove(int index)
        {
            var removed = Get(index);
           _internalArray.RemoveAt(index);

           return removed;
        }

        public void Clear()
        {
            _internalArray.Clear();
        }

        public override string ToString()
        {
            var str = "[";

            for (var i = 0; i < Size; i++)
            {
                if (i != Size - 1)
                {
                    str += _internalArray[i] + ", ";
                }
                else
                {
                    str += _internalArray[i] + "]";
                }
            }

            return str;
        }
    }
}