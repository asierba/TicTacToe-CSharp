namespace NoughtsAndCrosses
{
    /// <summary>
    /// NullObject pattern. A position that means is not found in the board or is invalid
    /// </summary>
    public class NoPosition : Position
    {
        public NoPosition()
            : base(-1, -1)
        {
        }
    }
}