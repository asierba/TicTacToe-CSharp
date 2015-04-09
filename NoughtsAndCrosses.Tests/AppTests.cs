namespace NoughtsAndCrosses.Tests
{
    using System;
    using System.IO;

    using Machine.Fakes;
    using Machine.Specifications;

    public class given_the_app_starts : WithSubject<App>
    {
        It should_prompt_the_user_to_begin_the_game = () => 
            The<IConsole>().WasToldTo(x => x.WriteLine("Press Any Key to begin the game"));

        It should_wait_for_user_input = () =>
            The<IConsole>().WasToldTo(x => x.ReadKey());

        static StringWriter output;
    }
}