namespace Events.EventDispatcher;

public interface IEventHandler<T> where T : IEvent
{
    void Handle(T e);
}