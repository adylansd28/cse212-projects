public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  
    /// For example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  
    /// Assume that length is a positive integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start

        // PLAN:
        // 1. Create an array of size 'length' to hold the multiples.
        // 2. Use a loop that runs from 0 to length - 1.
        // 3. In each iteration, calculate the multiple by multiplying 'number' by (index + 1).
        // 4. Store the multiple in the array at the current index.
        // 5. After the loop, return the array.

        double[] multiples = new double[length]; // Step 1

        for (int i = 0; i < length; i++) // Step 2
        {
            multiples[i] = number * (i + 1); // Steps 3 & 4
        }

        return multiples; // Step 5

        // TODO Problem 1 End
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start

        // PLAN:
        // 1. Check if the list is not empty and amount is valid (between 1 and data.Count).
        // 2. Use GetRange to take the last 'amount' elements from the list.
        // 3. Use RemoveRange to remove those elements from the end of the list.
        // 4. Use InsertRange to insert those elements at the beginning of the list.
        // This will complete the rotation to the right.

        if (data == null || data.Count == 0)
        {
            return; // Nothing to rotate
        }

        if (amount < 1 || amount > data.Count)
        {
            throw new ArgumentOutOfRangeException("amount", "Amount must be between 1 and the size of the list.");
        }

        // Step 2: Get the last 'amount' elements
        List<int> lastElements = data.GetRange(data.Count - amount, amount);

        // Step 3: Remove the last 'amount' elements
        data.RemoveRange(data.Count - amount, amount);

        // Step 4: Insert the elements at the beginning
        data.InsertRange(0, lastElements);

        // TODO Problem 2 End
    }
}