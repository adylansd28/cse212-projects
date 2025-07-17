/// <summary>
/// Defines a maze using a dictionary. The dictionary is provided by the
/// user when the Maze object is created. The dictionary will contain the
/// following mapping:
///
/// (x,y) : [left, right, up, down]
///
/// 'x' and 'y' are integers and represent locations in the maze.
/// 'left', 'right', 'up', and 'down' are booleans representing valid directions
///
/// If a direction is false, we assume there is a wall in that direction.
/// If a direction is true, movement is allowed.
/// If there is a wall, throw InvalidOperationException with the message "Can't go that way!".
/// </summary>
public class Maze
{
    private readonly Dictionary<(int, int), bool[]> _mazeMap;
    private int _currX = 1;
    private int _currY = 1;

    public Maze(Dictionary<(int, int), bool[]> mazeMap)
    {
        _mazeMap = mazeMap;
    }

    /// <summary>
    /// Attempt to move left in the maze.
    /// If allowed, decrease the X position by 1.
    /// If blocked by a wall, throw InvalidOperationException.
    /// </summary>
    public void MoveLeft()
    {
        var currentPosition = (_currX, _currY);
        if (!_mazeMap[currentPosition][0])
        {
            throw new InvalidOperationException("Can't go that way!");
        }
        _currX -= 1;
    }

    /// <summary>
    /// Attempt to move right in the maze.
    /// If allowed, increase the X position by 1.
    /// If blocked by a wall, throw InvalidOperationException.
    /// </summary>
    public void MoveRight()
    {
        var currentPosition = (_currX, _currY);
        if (!_mazeMap[currentPosition][1])
        {
            throw new InvalidOperationException("Can't go that way!");
        }
        _currX += 1;
    }

    /// <summary>
    /// Attempt to move up in the maze.
    /// If allowed, decrease the Y position by 1.
    /// If blocked by a wall, throw InvalidOperationException.
    /// </summary>
    public void MoveUp()
    {
        var currentPosition = (_currX, _currY);
        if (!_mazeMap[currentPosition][2])
        {
            throw new InvalidOperationException("Can't go that way!");
        }
        _currY -= 1;
    }

    /// <summary>
    /// Attempt to move down in the maze.
    /// If allowed, increase the Y position by 1.
    /// If blocked by a wall, throw InvalidOperationException.
    /// </summary>
    public void MoveDown()
    {
        var currentPosition = (_currX, _currY);
        if (!_mazeMap[currentPosition][3])
        {
            throw new InvalidOperationException("Can't go that way!");
        }
        _currY += 1;
    }

    /// <summary>
    /// Returns a string showing the current (x, y) position in the maze.
    /// </summary>
    public string GetStatus()
    {
        return $"Current location (x={_currX}, y={_currY})";
    }
}