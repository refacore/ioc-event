namespace Events.EventDispatcher;

public interface IEventDispatcher
{
    void Dispatch<T>(T e) where T : IEvent;
}
