namespace NoughtsAndCrosses.Tests
{
    using Machine.Fakes;
    using Machine.Specifications;

    public class given_a_new_board : WithSubject<GameBoard>
    {
        It should_be_empty = () =>
        {
            Subject.Display().ShouldBeEqualIgnoringCase("[ ] [ ] [ ]\n[ ] [ ] [ ]\n[ ] [ ] [ ]");
        };
    }
}
