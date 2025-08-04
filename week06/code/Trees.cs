public static class Trees
{
    /// <summary>
    /// Given a sorted list (sorted_list), create a balanced BST.  If the values in the
    /// sortedNumbers were inserted in order from left to right into the BST, then it
    /// would resemble a linked list (unbalanced). To get a balanced BST, the
    /// InsertMiddle function is called to find the middle item in the list to add
    /// first to the BST. The InsertMiddle function takes the whole list but also takes
    /// a range (first to last) to consider.  For the first call, the full range of 0 to
    /// Length-1 used.
    /// </summary>
    public static BinarySearchTree CreateTreeFromSortedList(int[] sortedNumbers)
    {
        var bst = new BinarySearchTree(); // Create an empty BST to start with 
        if (sortedNumbers.Length > 0)
        {
            InsertMiddle(sortedNumbers, 0, sortedNumbers.Length - 1, bst);
        }
        return bst;
    }

    /// <summary>
    /// This function will attempt to insert the item in the middle of 'sortedNumbers' into
    /// the 'bst' tree. The middle is determined by using indices represented by 'first' and
    /// 'last'.
    /// </summary>
    private static void InsertMiddle(int[] sortedNumbers, int first, int last, BinarySearchTree bst)
    {
        if (first > last) 
            return;

        int mid = (first + last) / 2;

        // Insert the middle element
        bst.Insert(sortedNumbers[mid]);

        // Recursively insert the left half
        InsertMiddle(sortedNumbers, first, mid - 1, bst);

        // Recursively insert the right half
        InsertMiddle(sortedNumbers, mid + 1, last, bst);
    }
}