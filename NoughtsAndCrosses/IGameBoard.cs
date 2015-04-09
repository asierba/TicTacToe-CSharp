namespace NoughtsAndCrosses
{
    public interface IGameBoard
    {
        string Display();

        bool GameIsOver();

        void Move(char player, int x, int y);
    }
}