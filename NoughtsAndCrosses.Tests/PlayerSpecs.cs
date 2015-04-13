namespace NoughtsAndCrosses.Tests
{
    using Machine.Fakes;
    using Machine.Specifications;

    class given_an_empty_board : WithSubject<Player>
    {
        Establish context = () =>
        {
            gameBoard = An<IGameBoard>();
            gameBoard
                .WhenToldTo(x => x.IsFree(Param.IsAny<Position>()))
               .Return(true);
        };

        Because of = () => position = Subject.NextMove(gameBoard);

        It should_move_to_any_square = () =>
        {
            position.X
                .ShouldBeLessThanOrEqualTo(2)
                .ShouldBeGreaterThanOrEqualTo(0);
            position.Y
                .ShouldBeLessThanOrEqualTo(2)
                .ShouldBeGreaterThanOrEqualTo(0);
        };

        static Position position;

        private static IGameBoard gameBoard;
    }

    class given_a_board_with_one_square_taken : WithSubject<Player>
    {
         Establish context = () =>
         {
             gameBoard = An<IGameBoard>();
             gameBoard
                 .WhenToldTo(x => x.IsFree(Param<Position>.Matches( p => p.X != 1 && p.Y != 1)))
                .Return(true);
         };

         Because of = () => position = Subject.NextMove(gameBoard);

        It should_move_to_any_other = () =>
        {
            position.X.ShouldNotEqual(1);
            position.Y.ShouldNotEqual(1);
        };

        static Position position;

        private static IGameBoard gameBoard;
    }

    class given_a_board_with_all_squares_but_one_taken : WithSubject<Player>
    {
        Establish context = () =>
        {
            gameBoard = An<IGameBoard>();
            gameBoard
                .WhenToldTo(x => x.IsFree(Param<Position>.Matches( p => p.X == 2 && p.Y == 2)))
               .Return(true);
        };

        Because of = () => position = Subject.NextMove(gameBoard);

        It should_move_to_that_square = () =>
        {
            position.X.ShouldEqual(2);
            position.Y.ShouldEqual(2);
        };

        static Position position;

        private static IGameBoard gameBoard;
    }

    class given_free_squares_but_game_is_over : WithSubject<Player>
    {
        Establish context = () =>
        {
            gameBoard = An<IGameBoard>();
            gameBoard
                .WhenToldTo(x => x.IsFree(Param.IsAny<Position>()))
               .Return(true);
            gameBoard
                .WhenToldTo(x => x.GameIsOver())
               .Return(true);
        };

        Because of = () => position = Subject.NextMove(gameBoard);

        It should_move_to_that_square = () =>
        {
            position.X.ShouldEqual(-1);
            position.Y.ShouldEqual(-1);
        };

        static Position position;

        private static IGameBoard gameBoard;
    }
    // game full // over
}
