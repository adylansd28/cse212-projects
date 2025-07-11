/// <summary>
/// A proper FIFO implementation of a basic queue for Person objects.
/// </summary>
public class PersonQueue
{
    private readonly List<Person> _queue = new();

    /// <summary>
    /// Gets the current number of people in the queue.
    /// </summary>
    public int Length => _queue.Count;

    /// <summary>
    /// Adds a person to the back of the queue (FIFO).
    /// </summary>
    /// <param name="person">The person to add</param>
    public void Enqueue(Person person)
    {
        _queue.Add(person); // ✅ Add to end of list
    }

    /// <summary>
    /// Removes and returns the person at the front of the queue (FIFO).
    /// </summary>
    /// <returns>The person at the front of the queue</returns>
    public Person Dequeue()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("Cannot dequeue from an empty queue.");
        }

        var person = _queue[0];    // ✅ Get first item
        _queue.RemoveAt(0);        // ✅ Remove from front
        return person;
    }

    /// <summary>
    /// Checks if the queue is empty.
    /// </summary>
    /// <returns>True if the queue has no people; otherwise false.</returns>
    public bool IsEmpty()
    {
        return _queue.Count == 0;
    }

    /// <summary>
    /// Returns a string representation of the queue contents.
    /// </summary>
    public override string ToString()
    {
        return $"[{string.Join(", ", _queue)}]";
    }
}