using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DoubleEndedQueue
{
    public interface IDeque<T>
    {
        T PeekHead();
        T PeekTail();
        void EnqueueHead(T value);
        void EnqueueTail(T value);
        T DequeueHead();
        T DequeueTail();
        bool IsEmpty { get; }
    } 
}
