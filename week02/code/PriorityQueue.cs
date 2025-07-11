using System;
using System.Collections.Generic;

/// <summary>
/// A priority queue where each item has a priority.
/// Enqueue always adds to the back.
/// Dequeue always removes the item with the highest priority.
/// Ties are broken FIFO: the first item with the highest priority is removed first.
/// </summary>
public class PriorityQueue
{
    private readonly List<PriorityItem> _queue = new();

    /// <summary>
    /// Adds a new value to the back of the queue with an associated priority.
    /// </summary>
    /// <param name="value">The value to add</param>
    /// <param name="priority">The priority (higher number = higher priority)</param>
    public void Enqueue(string value, int priority)
    {
        var newItem = new PriorityItem(value, priority);
        _queue.Add(newItem); // ✅ Always add to the back
    }

    /// <summary>
    /// Removes and returns the value with the highest priority.
    /// If multiple items have the same priority, the first one (FIFO) is removed.
    /// Throws InvalidOperationException if the queue is empty.
    /// </summary>
    /// <returns>The value with the highest priority</returns>
    public string Dequeue()
    {
        if (_queue.Count == 0)
        {
            throw new InvalidOperationException("The queue is empty.");
        }

        int highestPriorityIndex = 0;

        // ✅ Fix loop to check ALL items (inclusive)
        for (int index = 1; index < _queue.Count; index++)
        {
            if (_queue[index].Priority > _queue[highestPriorityIndex].Priority)
            {
                highestPriorityIndex = index;
            }
            // FIFO: do not update index if same priority
        }

        string value = _queue[highestPriorityIndex].Value;
        _queue.RemoveAt(highestPriorityIndex); // ✅ Remove it
        return value;
    }

    /// <summary>
    /// Returns a string representation of the queue contents.
    /// </summary>
    public override string ToString()
    {
        return $"[{string.Join(", ", _queue)}]";
    }
}

/// <summary>
/// Helper class for an item with a value and a priority.
/// </summary>
internal class PriorityItem
{
    internal string Value { get; set; }
    internal int Priority { get; set; }

    internal PriorityItem(string value, int priority)
    {
        Value = value;
        Priority = priority;
    }

    public override string ToString()
    {
        return $"{Value} (Pri:{Priority})";
    }
}