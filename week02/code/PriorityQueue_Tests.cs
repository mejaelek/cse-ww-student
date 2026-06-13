using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue three items with different priorities: "Bob" (1), "Tim" (2), "Sue" (3).
    // Dequeue should always return the highest priority item first.
    // Expected Result: "Sue" (3), then "Tim" (2), then "Bob" (1).
    // Defect(s) Found: 1) The loop used _queue.Count - 1, skipping the last element.
    // Fixed to _queue.Count. 2) Item was found but never removed. Added _queue.RemoveAt(highPriorityIndex).
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Bob", 1);
        priorityQueue.Enqueue("Tim", 2);
        priorityQueue.Enqueue("Sue", 3);

        Assert.AreEqual("Sue", priorityQueue.Dequeue());
        Assert.AreEqual("Tim", priorityQueue.Dequeue());
        Assert.AreEqual("Bob", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue two items with the same highest priority: "Bob" (3) added before "Sue" (3).
    // Expected Result: "Bob" should be dequeued first because it was added first (FIFO for equal priorities).
    // Defect(s) Found: The >= comparison caused the last equal-priority item to win instead of the first.
    // Fixed by changing >= to > so the first item with the highest priority is always selected.
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Bob", 3);
        priorityQueue.Enqueue("Tim", 1);
        priorityQueue.Enqueue("Sue", 3);

        Assert.AreEqual("Bob", priorityQueue.Dequeue(), "When priorities are equal, the first item added should be dequeued first (FIFO).");
    }

    [TestMethod]
    // Scenario: Dequeue from an empty queue.
    // Expected Result: InvalidOperationException thrown with message "The queue is empty."
    // Defect(s) Found: No defect. The exception is thrown correctly.
    public void TestPriorityQueue_EmptyQueue()
    {
        var priorityQueue = new PriorityQueue();

        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
        catch (AssertFailedException)
        {
            throw;
        }
        catch (Exception e)
        {
            Assert.Fail(string.Format("Unexpected exception of type {0} caught: {1}", e.GetType(), e.Message));
        }
    }

    [TestMethod]
    // Scenario: The highest priority item is the last one added (last in the list).
    // Expected Result: "D" (priority 10) should be dequeued first even though it was added last.
    // Defect(s) Found: The loop used _queue.Count - 1, which skipped the last element entirely,
    // so "D" would never be found. Fixed by changing loop bound to _queue.Count.
    public void TestPriorityQueue_HighestPriorityIsLast()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 1);
        priorityQueue.Enqueue("B", 3);
        priorityQueue.Enqueue("C", 5);
        priorityQueue.Enqueue("D", 10);

        Assert.AreEqual("D", priorityQueue.Dequeue());
        Assert.AreEqual("C", priorityQueue.Dequeue());
        Assert.AreEqual("B", priorityQueue.Dequeue());
        Assert.AreEqual("A", priorityQueue.Dequeue());
    }
}
