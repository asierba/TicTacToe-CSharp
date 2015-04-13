namespace NoughtsAndCrosses
{
    public interface IGameBoard
    {
        string Display();

        bool GameIsOver();

        void Move(Player player, Position position);

        bool IsFree(Position position);
    }
}