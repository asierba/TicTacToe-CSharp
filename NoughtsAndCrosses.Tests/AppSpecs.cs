namespace NoughtsAndCrosses.Tests
{
    using Machine.Fakes;
    using Machine.Specifications;

    public class given_the_application_runs : WithSubject<Application>
    {
        Because of = () =>
            Subject.Run();

        It should_prompt_the_user_to_begin_the_game = () => 
            The<IConsole>().WasToldTo(x => x.WriteLine("Press Any Key to begin the game"));

        It should_wait_for_user_input = () =>
            The<IConsole>().WasToldTo(x => x.ReadKey());
    }

    public class given_the_application_runs_and_the_user_presses_a_key : WithSubject<Application>
    {
        Because of = () =>
            Subject.Run();

        It should_show_an_empty_board = () =>
        {
            The<IConsole>().WasToldTo(x => x.WriteLine("Game Board:"));
            The<IConsole>().WasToldTo(x => x.WriteLine(@"[ ][ ][ ]
[ ][ ][ ]
[ ][ ][ ]
")); // TODO is this the correct place to test this?
        };
    }
}