namespace NoughtsAndCrosses.Tests
{
    using Machine.Fakes;
    using Machine.Specifications;

    using Moq;

    using It = Machine.Specifications.It;

    public class given_the_application_runs : WithSubject<Application>
    {
        Establish context = () =>
            The<IGameBoard>()
                .WhenToldTo(x => x.GameIsOver())
                .Return(true);

        Because of = () =>
            Subject.Run();

        It should_prompt_the_user_to_begin_the_game = () => 
            The<IConsole>().WasToldTo(x => x.WriteLine("Press Any Key to begin the game"));

        It should_wait_for_user_input = () =>
            The<IConsole>().WasToldTo(x => x.ReadKey());
    }

    public class given_the_application_runs_and_the_user_presses_a_key : WithSubject<Application>
    {
        Establish context = () =>
            The<IGameBoard>()
            .WhenToldTo(x => x.GameIsOver())
            .Return(true);

        Because of = () =>
            Subject.Run();

        It should_show_current_board = () =>
        {
            The<IConsole>().WasToldTo(x => x.WriteLine("Game Board:"));
            The<IGameBoard>().WasToldTo(x => x.Display());
        };

        It a_player_should_make_a_move = () =>
            The<IGameBoard>()
                .WasToldTo(x => x.Move(Param.IsAny<char>(), Param.IsAny<int>(), Param.IsAny<int>()));
    }

    public class given_the_game_is_over_after_two_moves : WithSubject<Application>
    {
        Establish game_is_over_after_two_moves = () =>
        {
            The<IGameBoard>()
                .WhenToldTo(x => x.Move(Param.IsAny<char>(), Param.IsAny<int>(), Param.IsAny<int>()))
                .Callback(() =>
                {
                    The<IGameBoard>().WhenToldTo(x => x.Move(Param.IsAny<char>(), Param.IsAny<int>(), Param.IsAny<int>()))
                        .Callback(() =>
                        {
                            The<IGameBoard>().WhenToldTo(x => x.GameIsOver()).Return(true);
                        });
                });
        };

        Because of = () =>
            Subject.Run();

        It should_show_current_board_twice = () =>
            The<IGameBoard>().WasToldTo(x => x.Display()).Times(2);

        It both_players_should_make_a_move = () =>
        {
            The<IGameBoard>()
                .WasToldTo(x => x.Move('X', Param.IsAny<int>(), Param.IsAny<int>()));
            The<IGameBoard>()
                .WasToldTo(x => x.Move('O', Param.IsAny<int>(), Param.IsAny<int>()));
        };
            
    }
}