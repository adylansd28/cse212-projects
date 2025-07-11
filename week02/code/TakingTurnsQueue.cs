/// <summary>
/// This queue is circular. When people are added via AddPerson, they are added to the
/// back of the queue (FIFO). When GetNextPerson is called, the next person
/// in the queue is returned and may be placed back into the queue if they still have turns left.
/// A turns value of 0 or less means the person has infinite turns.
/// If the queue is empty, an InvalidOperationException is thrown.
/// </summary>
public class TakingTurnsQueue
{
    private readonly PersonQueue _people = new();

    /// <summary>
    /// Gets the current number of people in the queue.
    /// </summary>
    public int Length => _people.Length;

    /// <summary>
    /// Adds a new person to the queue with the given name and number of turns.
    /// </summary>
    /// <param name="name">The name of the person</param>
    /// <param name="turns">The number of turns (0 or less means infinite turns)</param>
    public void AddPerson(string name, int turns)
    {
        var person = new Person(name, turns);
        _people.Enqueue(person);
    }

    /// <summary>
    /// Gets the next person in the queue.
    /// If the person has remaining turns, they may be re-enqueued.
    /// If they have infinite turns (turns <= 0), they are always re-enqueued without changing their turns.
    /// If the queue is empty, throws an InvalidOperationException.
    /// </summary>
    /// <returns>The next person in line</returns>
    public Person GetNextPerson()
    {
        if (_people.IsEmpty())
        {
            throw new InvalidOperationException("No one in the queue.");
        }

        var person = _people.Dequeue();

        if (person.Turns > 0)
        {
            person.Turns -= 1;

            if (person.Turns > 0)
            {
                _people.Enqueue(person);
            }
            // If turns reach 0, do not re-enqueue.
        }
        else
        {
            // Infinite turns: do not decrement, always re-enqueue.
            _people.Enqueue(person);
        }

        return person;
    }

    /// <summary>
    /// Returns a string representation of the queue contents.
    /// </summary>
    public override string ToString()
    {
        return _people.ToString();
    }
}