namespace NoughtsAndCrosses.Tests
{
    using Machine.Fakes;
    using Machine.Specifications;

    using NUnit.Framework;

    public class given_a_new_board : WithSubject<GameBoard>
    {
        It should_be_empty = () => {
            Subject.Display().ShouldEqual(
@"[ ][ ][ ]
[ ][ ][ ]
[ ][ ][ ]
");
            for (var y = 0; y <= 2; y++)
                for (var x = 0; x <= 2; x++)
             Subject.IsFree(new Position(x, y)).ShouldBeTrue();
};
    }

    public class given_a_player_makes_a_move
    {
        [TestCase('X', 0, 0, 
@"[X][ ][ ]
[ ][ ][ ]
[ ][ ][ ]
")]
        [TestCase('O', 1, 1,
@"[ ][ ][ ]
[ ][O][ ]
[ ][ ][ ]
")]
        [TestCase('X', 0, 2,
@"[ ][ ][ ]
[ ][ ][ ]
[X][ ][ ]
")]
        public void should_be_displayed_in_the_board(char player, int x, int y, string board)
        {
            var gameBoard = new GameBoard();
            gameBoard.Move(new Player(player), new Position(x, y));
            gameBoard.Display().ShouldEqual(board);
        }
    }
}
