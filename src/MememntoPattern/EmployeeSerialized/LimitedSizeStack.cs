using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MememntoPattern.EmployeeSerialized
{
    public class LimitedSizeStack<T> : LinkedList<T>
    {
        private readonly int maxSize;
        public LimitedSizeStack(int maxSize)
        {
            this.maxSize = maxSize;
        }

        public void Push(T item)
        {
            AddFirst(item);

            if (Count > maxSize)
                RemoveLast();
        }

        public T Pop()
        {
            var item = First.Value;
            RemoveFirst();
            return item;
        }
    }
}
