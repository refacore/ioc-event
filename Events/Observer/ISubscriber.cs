namespace Events.Observer;

public interface ISubscriber
{
    void Handle(EventContext context);
}
