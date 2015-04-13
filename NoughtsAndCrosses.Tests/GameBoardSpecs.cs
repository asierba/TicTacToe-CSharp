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

        It game_should_not_be_over = () =>
           Subject.GameIsOver().ShouldBeFalse();
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

    public class given_a_player_makes_three_in_diagonal : WithSubject<GameBoard>
    {
        Establish context = () =>
        {
            var player = new Player('X');

            Subject.Move(player, new Position(0, 0));
            Subject.Move(player, new Position(1, 1));
            Subject.Move(player, new Position(2, 2));
        };

        It game_should_be_over = () =>
            Subject.GameIsOver().ShouldBeTrue();

        It player_is_the_winner = () =>
            Subject.Result.ShouldEqual("X Wins!");
    }

    public class given_a_player_makes_three_in_oposit_diagonal : WithSubject<GameBoard>
    {
        Establish context = () =>
        {
            var player = new Player('O');

            Subject.Move(player, new Position(0, 2));
            Subject.Move(player, new Position(1, 1));
            Subject.Move(player, new Position(2, 0));
        };

        It game_should_be_over = () =>
            Subject.GameIsOver().ShouldBeTrue();

        It player_is_the_winner = () =>
           Subject.Result.ShouldEqual("O Wins!");
    }

    public class given_a_player_makes_three_in_a_row : WithSubject<GameBoard>
    {
        Establish context = () =>
        {
            var player = new Player('X');

            Subject.Move(player, new Position(0, 0));
            Subject.Move(player, new Position(1, 0));
            Subject.Move(player, new Position(2, 0));
        };

        It game_should_be_over = () =>
            Subject.GameIsOver().ShouldBeTrue();

        It player_is_the_winner = () =>
           Subject.Result.ShouldEqual("X Wins!");
    }

    // TODO delete this one
    public class given_a_player_makes_three_in_a_row2 : WithSubject<GameBoard>
    {
        Establish context = () =>
        {
            var player = new Player('O');

            Subject.Move(player, new Position(0, 1));
            Subject.Move(player, new Position(1, 1));
            Subject.Move(player, new Position(2, 1));
        };

        It game_should_be_over = () =>
            Subject.GameIsOver().ShouldBeTrue();

        It player_is_the_winner = () =>
           Subject.Result.ShouldEqual("O Wins!");
    }

    public class given_a_player_makes_three_in_a_column : WithSubject<GameBoard>
    {
        Establish context = () =>
        {
            var player = new Player('O');

            Subject.Move(player, new Position(2, 0));
            Subject.Move(player, new Position(2, 1));
            Subject.Move(player, new Position(2, 2));
        };

        It game_should_be_over = () =>
            Subject.GameIsOver().ShouldBeTrue();

        It player_is_the_winner = () =>
          Subject.Result.ShouldEqual("O Wins!");
    }

    public class given_the_board_is_full : WithSubject<GameBoard>
    {
        Establish context = () =>
        {
            var player1 = new Player('X');
            var player2 = new Player('O');

            Subject.Move(player1, new Position(0, 0));
            Subject.Move(player2, new Position(1, 1));
            Subject.Move(player1, new Position(2, 2));
            Subject.Move(player2, new Position(1, 0));
            Subject.Move(player1, new Position(1, 2));
            Subject.Move(player2, new Position(0, 2));
            Subject.Move(player1, new Position(0, 1));
            Subject.Move(player2, new Position(2, 1));
            Subject.Move(player1, new Position(2, 0));
        };

        It game_should_be_over = () =>
            Subject.GameIsOver().ShouldBeTrue();

        It should_be_a_draw = () =>
           Subject.Result.ShouldEqual("Draw!");
    }
}
