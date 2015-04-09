namespace NoughtsAndCrosses.Tests
{
    using System;
    using System.IO;

    using Machine.Fakes;
    using Machine.Specifications;

    public class given_the_app_starts : WithSubject<App>
    {
        Establish context = () =>
        {
            output = new StringWriter();
            Console.SetOut(output);
        };

        It should_prompt_the_user_to_begin_the_game = () =>
        {
            output.ToString().ShouldContain("Press Any Key to begin the game");
        };

        static StringWriter output;
    }
}