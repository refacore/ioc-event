using Microsoft.Extensions.DependencyInjection;

namespace Events.EventDispatcher;

public class Dispatcher : IEventDispatcher
{
    private readonly IServiceProvider serviceProvider;

    public Dispatcher(IServiceProvider serviceProvider)
    {
        this.serviceProvider = serviceProvider;
    }

    public void Dispatch<T>(T e) where T : IEvent
    {
        var handlers = serviceProvider.GetServices<IEventHandler<T>>();

        foreach (var handler in handlers)
        {
            handler.Handle(e);
        }
    }
}
