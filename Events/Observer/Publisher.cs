namespace Events.Observer;

public class Publisher : IPublisher
{
    private readonly List<ISubscriber> subscribers = new List<ISubscriber>();

    public void NotifySubscribers(EventContext context)
    {
        foreach (var subscriber in subscribers)
        {
            subscriber.Handle(context);
        }
    }

    public void Subscribe(ISubscriber subscriber)
    {
        subscribers.Add(subscriber);
    }

    public void Unsubscribe(ISubscriber subscriber)
    {
        subscribers.Remove(subscriber);
    }
}
