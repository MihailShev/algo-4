using System;

namespace algo_4
{
    public class MatrixArray<T> : IArray<T>
    {
        private readonly IArray<IArray<T>> _box;
        private readonly int _line;
        private const int DefaultLineSize = 10;

        public MatrixArray(int lineSize)
        {
            _box = new FactorArray<IArray<T>>();
            _line = lineSize;
            Size = 0;
        }

        public MatrixArray() : this(DefaultLineSize)
        {
        }

        public int Size { get; private set; }

        public bool IsEmpty()
        {
            return Size == 0;
        }

        public void Append(T item)
        {
            if (Size == _box.Size * _line)
                _box.Append(new VectorArray<T>(_line));

            _box.Get(Size / _line).Append(item);
            Size++;
        }

        public void AppendAt(T item, int index)
        {
            _box.Get(index / _line).AppendAt(item, index % _line);
        }

        public T Get(int index)
        {
            return _box.Get(index / _line).Get(index % _line);
        }

        public T Remove(int index)
        {
            var removed = Get(index);
            var lineIndex = index / _line;
            var elementIndex = (index % _line) + 1;
            var vector = _box.Get(lineIndex);
            
            for (;;)
            {
                T nextElem;

                for (; elementIndex < vector.Size; elementIndex++)
                {
                    // Получаем следующий элемент
                    nextElem = vector.Get(elementIndex);
                    
                    // Перемещаем его на одну ячеку назад
                    vector.AppendAt(nextElem, elementIndex - 1);
                }

                lineIndex++;
                
                // Если нет следующего вектора, то удаляем последний элемент из последнего вектора
                if (lineIndex >= _box.Size)
                {
                    vector.Remove(elementIndex - 1);
                    
                    // Удаляем вектор, если он пустой
                    if (vector.Size == 0)
                    {
                        _box.Remove(lineIndex - 1);
                    }
                    break;
                }

                var nextVector = _box.Get(lineIndex);
                
                // Получаем первый элемент из следующего вектора
                nextElem = nextVector.Get(0);
                // И помещаем его в последний элемент предыдущего вектора
                vector.AppendAt(nextElem, elementIndex - 1);
                vector = nextVector;

                elementIndex = 1;
            }

            Size--;
            return removed;
        }

        public override string ToString()
        {
            var str = "[";

            for (var i = 0; i < Size; i++)
            {
                if (i != Size - 1)
                {
                    str += Get(i) + ", ";
                }
                else
                {
                    str += Get(i) + "]";
                }
            }

            return str;
        }
    }
}