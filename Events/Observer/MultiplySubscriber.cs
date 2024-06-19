namespace Events.Observer;

public class MultiplySubscriber : ISubscriber
{
    public void Handle(EventContext context)
    {
        Console.WriteLine($"PlusSubscriber handle event: {context.Id * 3}");
    }
}
