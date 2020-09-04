using System;

namespace algo_4.PriorityQueue
{
    public class PriorityQueue<T>
    {
        private readonly IArray<IArray<T>> _box;

        public int Size { get; private set; }

        public PriorityQueue()
        {
            _box = new SingleArray<IArray<T>>();
        }


        public void Enqueue(uint priority, T item)
        {
            Size++;
            if (priority + 1 > _box.Size)
            {
                for (var i = _box.Size; i <= priority; i++)
                {
                    _box.Append(new FactorArray<T>());
                }
            }

            _box.Get((int) priority).Append(item);
        }

        public T Dequeue()
        {
            for (var i = 0; i < _box.Size; i++)
            {
                var queue = _box.Get(i);
                if (queue.Size > 0)
                {
                    Size--;
                    return queue.Remove(0);
                }
            }

            throw new Exception("Queue is empty");
        }

        public bool isEmpty()
        {
            return Size == 0;
        }

        public override string ToString()
        {
            if (isEmpty())
            {
                return "priority queue is empty";
            }

            var str = "";

            for (var i = 0; i < _box.Size; i++)
            {
                var queue = _box.Get(i);
                str += "\npriority " + i + ": ";

                if (queue.Size > 0)
                    for (var j = 0; j < queue.Size; j++)
                        str += queue.Get(j) + "; ";
                else
                    str += "empty";
            }

            return str;
        }
    }
}