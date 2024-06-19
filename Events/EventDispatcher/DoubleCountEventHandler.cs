namespace Events.EventDispatcher;

public class DoubleCountEventHandler : IEventHandler<CountEvent>
{
    public void Handle(CountEvent e)
    {
        Console.WriteLine($"CountEventHandler handle event: {e.Id * 2}");
    }
}
