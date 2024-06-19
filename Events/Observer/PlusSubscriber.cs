namespace Events.Observer;

public class PlusSubscriber : ISubscriber
{
    public void Handle(EventContext context)
    {
        Console.WriteLine($"PlusSubscriber handle event: {context.Id + 1}");
    }
}
