using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Add multiple items with different priorities.
    // Expected Result: Dequeue returns the highest priority item.
    // Defect(s) Found: TBD
    public void TestPriorityQueue_HighestPriority()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("A", 2);
        pq.Enqueue("B", 5);
        pq.Enqueue("C", 3);

        Assert.AreEqual("B", pq.Dequeue());
    }

    [TestMethod]
    // Scenario: Add items with same highest priority.
    // Expected Result: Dequeue returns the first of those items (FIFO).
    // Defect(s) Found: TBD
    public void TestPriorityQueue_TieBreakerFIFO()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("A", 4);
        pq.Enqueue("B", 4);
        pq.Enqueue("C", 2);

        Assert.AreEqual("A", pq.Dequeue());
    }

    [TestMethod]
    // Scenario: Dequeue multiple items to check order.
    // Expected Result: Items are removed from highest to lowest priority, FIFO for ties.
    // Defect(s) Found: TBD
    public void TestPriorityQueue_DequeueMultipleOrder()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("A", 1);
        pq.Enqueue("B", 5);
        pq.Enqueue("C", 5);
        pq.Enqueue("D", 3);

        Assert.AreEqual("B", pq.Dequeue());
        Assert.AreEqual("C", pq.Dequeue());
        Assert.AreEqual("D", pq.Dequeue());
        Assert.AreEqual("A", pq.Dequeue());
    }

    [TestMethod]
    // Scenario: Try to dequeue from an empty queue.
    // Expected Result: Throws InvalidOperationException with correct message.
    // Defect(s) Found: TBD
    public void TestPriorityQueue_DequeueEmptyThrows()
    {
        var pq = new PriorityQueue();

        try
        {
            pq.Dequeue();
            Assert.Fail("Expected InvalidOperationException was not thrown.");
        }
        catch (InvalidOperationException ex)
        {
            Assert.AreEqual("The queue is empty.", ex.Message);
        }
    }
}