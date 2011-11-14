using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DoubleEndedQueue;

namespace DoubleEndedQueueTest
{
    [TestClass]
    public class StringDequeTests
    {
        [TestMethod]
        public void A_new_StringDeque_should_be_empty()
        {
            var deque = new Deque<String>();
            Assert.IsTrue(deque.IsEmpty);
        }

        [TestMethod]
        public void A_new_StringDeque_with_one_head_queued_string_should_not_be_empty()
        {
            var deque = new Deque<String>();
            deque.EnqueueHead("dummy");
            Assert.IsFalse(deque.IsEmpty);
        }

        [TestMethod]
        public void A_new_StringDeque_with_one_tail_queued_string_should_not_be_empty()
        {
            var deque = new Deque<String>();
            deque.EnqueueTail("dummy");
            Assert.IsFalse(deque.IsEmpty);
        }

        [TestMethod]
        public void A_new_StringDeque_with_more_than_one_head_queued_string_should_not_be_empty()
        {
            var deque = new Deque<String>();
            deque.EnqueueHead("dummy");
            deque.EnqueueHead("dummy");
            Assert.IsFalse(deque.IsEmpty);
        }

        [TestMethod]
        public void A_new_StringDeque_with_more_than_one_tail_queued_string_should_not_be_empty()
        {
            var deque = new Deque<String>();
            deque.EnqueueTail("dummy");
            deque.EnqueueTail("dummy");
            Assert.IsFalse(deque.IsEmpty);
        }

        [TestMethod]
        public void A_new_StringDeque_with_one_head_queued_string_when_head_peeked_should_not_be_empty_and_should_return_same_string()
        {
            var deque = new Deque<String>();
            deque.EnqueueHead("dummy");
            var item = deque.PeekHead();
            Assert.IsFalse(deque.IsEmpty);
            Assert.AreEqual("dummy", item);
        }

        [TestMethod]
        public void A_new_StringDeque_with_one_head_queued_string_when_tail_peeked_should_not_be_empty_and_should_return_same_string()
        {
            var deque = new Deque<String>();
            deque.EnqueueHead("dummy");
            var item = deque.PeekTail();
            Assert.IsFalse(deque.IsEmpty);
            Assert.AreEqual("dummy", item);
        }

        [TestMethod]
        public void A_new_StringDeque_with_one_tail_queued_string_when_head_peeked_should_not_be_empty_and_should_return_same_string()
        {
            var deque = new Deque<String>();
            deque.EnqueueTail("dummy");
            var item = deque.PeekHead();
            Assert.IsFalse(deque.IsEmpty);
            Assert.AreEqual("dummy", item);
        }

        [TestMethod]
        public void A_new_StringDeque_with_one_tail_queued_string_when_tail_peeked_should_not_be_empty_and_should_return_same_string()
        {
            var deque = new Deque<String>();
            deque.EnqueueTail("dummy");
            var item = deque.PeekTail();
            Assert.IsFalse(deque.IsEmpty);
            Assert.AreEqual("dummy", item);
        }

        [TestMethod]
        public void A_new_StringDeque_with_one_head_queued_string_when_head_dequeued_should_be_empty_and_should_return_same_string()
        {
            var deque = new Deque<String>();
            deque.EnqueueHead("dummy");
            var result = deque.DequeueHead();
            Assert.IsTrue(deque.IsEmpty);
            Assert.AreEqual("dummy", result);
        }

        [TestMethod]
        public void A_new_StringDeque_with_one_head_queued_string_when_tail_dequeued_should_be_empty_and_should_return_same_string()
        {
            var deque = new Deque<String>();
            deque.EnqueueHead("dummy");
            var result = deque.DequeueTail();
            Assert.IsTrue(deque.IsEmpty);
            Assert.AreEqual("dummy", result);
        }

        [TestMethod]
        public void A_new_StringDeque_with_one_tail_queued_string_when_head_dequeued_should_be_empty_and_should_return_same_string()
        {
            var deque = new Deque<String>();
            deque.EnqueueTail("dummy");
            var result = deque.DequeueHead();
            Assert.IsTrue(deque.IsEmpty);
            Assert.AreEqual("dummy", result);
        }

        [TestMethod]
        public void A_new_StringDeque_with_one_tail_queued_string_when_tail_dequeued_should_be_empty_and_should_return_same_string()
        {
            var deque = new Deque<String>();
            deque.EnqueueTail("dummy");
            var result = deque.DequeueTail();
            Assert.IsTrue(deque.IsEmpty);
            Assert.AreEqual("dummy", result);
        }

        [TestMethod]
        public void A_new_StringDeque_with_two_tail_queued_strings_when_tail_dequeued_should_return_second_string()
        {
            var deque = new Deque<String>();
            deque.EnqueueTail("dummy1");
            deque.EnqueueTail("dummy2");
            var result = deque.DequeueTail();
            Assert.AreEqual("dummy2", result);
        }

        [TestMethod]
        public void A_new_StringDeque_with_two_tail_queued_strings_when_head_dequeued_should_return_first_string()
        {
            var deque = new Deque<String>();
            deque.EnqueueTail("dummy1");
            deque.EnqueueTail("dummy2");
            var result = deque.DequeueHead();
            Assert.AreEqual("dummy1", result);
        }

        [TestMethod]
        public void A_new_StringDeque_with_two_head_queued_strings_when_tail_dequeued_should_return_first_string()
        {
            var deque = new Deque<String>();
            deque.EnqueueHead("dummy1");
            deque.EnqueueHead("dummy2");
            var result = deque.DequeueTail();
            Assert.AreEqual("dummy1", result);
        }

        [TestMethod]
        public void A_new_StringDeque_with_two_head_queued_strings_when_head_dequeued_should_return_second_string()
        {
            var deque = new Deque<String>();
            deque.EnqueueHead("dummy1");
            deque.EnqueueHead("dummy2");
            var result = deque.DequeueHead();
            Assert.AreEqual("dummy2", result);
        }

        [TestMethod]
        public void A_new_StringDeque_with_one_head_queued_string_should_have_a_capacity_greater_than_zero()
        {
            var deque = new Deque<String>();
            deque.EnqueueHead("dummy");
            Assert.IsTrue(deque.Capacity > 0);
        }

        [TestMethod]
        public void A_StringDeque_with_queued_string_count_two_less_than_capacity_when_head_queued_should_not_increase_capacity()
        {
            var deque = new Deque<String>();
            deque.EnqueueHead(deque.Count.ToString());
            while (deque.Count < (deque.Capacity - 2))
            {
                deque.EnqueueHead(deque.Count.ToString());
            }
            var oldCapacity = deque.Capacity;
            deque.EnqueueHead("dummy");
            Assert.IsFalse(deque.Capacity > oldCapacity);
        }

        [TestMethod]
        public void A_StringDeque_with_queued_string_count_two_less_than_capacity_when_tail_queued_should_not_increase_capacity()
        {
            var deque = new Deque<String>();
            deque.EnqueueTail(deque.Count.ToString());
            while (deque.Count < (deque.Capacity - 2))
            {
                deque.EnqueueTail(deque.Count.ToString());
            }
            var oldCapacity = deque.Capacity;
            deque.EnqueueTail("dummy");
            Assert.IsFalse(deque.Capacity > oldCapacity);
        }

        [TestMethod]
        public void A_StringDeque_with_queued_string_count_one_less_than_capacity_when_head_queued_should_increase_capacity()
        {
            var deque = new Deque<String>();
            deque.EnqueueHead(deque.Count.ToString());
            while (deque.Count < (deque.Capacity - 1))
            {
                deque.EnqueueHead(deque.Count.ToString());
            }
            var oldCapacity = deque.Capacity;
            deque.EnqueueHead("dummy");
            Assert.IsTrue(deque.Capacity > oldCapacity);
        }

        [TestMethod]
        public void A_StringDeque_with_queued_string_count_one_less_than_capacity_when_tail_queued_should_increase_capacity()
        {
            var deque = new Deque<String>();
            deque.EnqueueTail(deque.Count.ToString());
            while (deque.Count < (deque.Capacity - 1))
            {
                deque.EnqueueTail(deque.Count.ToString());
            }
            var oldCapacity = deque.Capacity;
            deque.EnqueueTail("dummy");
            Assert.IsTrue(deque.Capacity > oldCapacity);
        }
    }
}
