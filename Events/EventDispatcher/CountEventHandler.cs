namespace Events.EventDispatcher;

public class CountEventHandler : IEventHandler<CountEvent>
{
    public void Handle(CountEvent e)
    {
        Console.WriteLine($"CountEventHandler handle event: {e.Id}");
    }
}
