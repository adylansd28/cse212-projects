public class Node
{
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data)
    {
        this.Data = data;
    }

    /// <summary>
    /// Inserts a value into the tree while ensuring uniqueness.
    /// </summary>
    public void Insert(int value)
    {
        // Problem 1: Insert unique values only
        if (value == Data)
        {
            // Value already exists; do not insert duplicates
            return;
        }

        if (value < Data)
        {
            // Insert to the left
            if (Left is null)
                Left = new Node(value);
            else
                Left.Insert(value);
        }
        else // value > Data
        {
            // Insert to the right
            if (Right is null)
                Right = new Node(value);
            else
                Right.Insert(value);
        }
    }

    /// <summary>
    /// Checks whether a value exists in the tree using recursion.
    /// </summary>
    public bool Contains(int value)
    {
        // Problem 2: Recursive search
        if (value == Data)
            return true;
        else if (value < Data)
            return Left != null && Left.Contains(value);
        else // value > Data
            return Right != null && Right.Contains(value);
    }

    /// <summary>
    /// Calculates the height of the tree using recursion.
    /// </summary>
    public int GetHeight()
    {
        // Problem 4: Height of the tree
        int leftHeight = (Left != null) ? Left.GetHeight() : 0;
        int rightHeight = (Right != null) ? Right.GetHeight() : 0;
        return 1 + Math.Max(leftHeight, rightHeight);
    }
}