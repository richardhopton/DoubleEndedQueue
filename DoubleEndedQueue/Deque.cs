using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace DoubleEndedQueue
{
    public class Deque<T> : IDeque<T>
    {
        private static readonly T[] emptyArray = new T[0];
        
        private Int32 startIndex = 0;
        private Int32 count = 0;
        private T[] items = emptyArray;

        private enum HeadOrTail
        {
            Head,
            Tail
        }

        public Int32 Capacity
        {
            get { return items.Length; }
        }

        public Int32 Count
        {
            get { return count; }
        }

        private void EnsureCapacity(HeadOrTail headOrTail)
        {
            var resizeCollection = (items.Length == 0) || ((count + 2) > items.Length);
            var reorderCollection = resizeCollection;
            if (!reorderCollection && (count > 0))
            {
                switch (headOrTail)
                {
                    case Deque<T>.HeadOrTail.Head:
                        reorderCollection = (startIndex == 0);
                        break;
                    case Deque<T>.HeadOrTail.Tail:
                        reorderCollection = ((startIndex + count) == items.Length);
                        break;
                }
            }

            if (reorderCollection)
            {
                var capacity = items.Length;
                if (resizeCollection)
                {
                    capacity = items.Length == 0 ? 4 : items.Length * 2;
                }
                var newItems = new T[capacity];
                var newStartIndex = ((capacity - count) / 2);

                if (count > 0)
                {
                    Array.Copy(items, startIndex, newItems, newStartIndex, count);
                }
                items = newItems;
                startIndex = newStartIndex;
            }
        }

        public T PeekHead()
        {
            var result = default(T);
            if (count > 0)
            {
                result = items[startIndex];
            }
            return result;
        }

        public T PeekTail()
        {
            var result = default(T);
            if (count > 0)
            {
                var itemIndex = startIndex + (count - 1);
                result = items[itemIndex];
            }
            return result;
        }
        
        public void EnqueueHead(T value)
        {
            EnsureCapacity(HeadOrTail.Head);
            items[startIndex-1] = value;
            startIndex--;
            count++;
        }

        public void EnqueueTail(T value)
        {
            EnsureCapacity(HeadOrTail.Tail);
            items[startIndex+count] = value;
            count++;
        }

        public T DequeueHead()
        {
            var result = default(T);
            if (count > 0)
            {
                result = items[startIndex];
                items[startIndex] = default(T);
                count--;
                if (count > 0)
                {
                    startIndex++;
                }
                else
                {
                    startIndex = (items.Length / 2);
                }
            }
            return result;
        }

        public T DequeueTail()
        {
            var result = default(T);
            if (count > 0)
            {
                var itemIndex = startIndex + (count - 1);
                result = items[itemIndex];
                items[itemIndex] = default(T);
                count--;
                if (count == 0)
                {
                    startIndex = (items.Length / 2);
                }
            }
            return result;
        }

        public bool IsEmpty
        {
            get { return (count == 0); }
        }
    }
}
