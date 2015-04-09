namespace NoughtsAndCrosses.Tests
{
    using Machine.Fakes;
    using Machine.Specifications;

    using NUnit.Framework;

    public class given_a_new_board : WithSubject<GameBoard>
    {
        It should_be_empty = () =>
            Subject.Display().ShouldEqual(
@"[ ][ ][ ]
[ ][ ][ ]
[ ][ ][ ]
");
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
            gameBoard.Move(player, x, y);
            gameBoard.Display().ShouldEqual(board);
        }
    }
}
