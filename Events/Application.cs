using Events.CSharpEvent;
using Events.EventDispatcher;
using Events.Observer;

namespace Events;

public class Application
{
    private readonly IEventDispatcher eventDispatcher;

    private readonly IPublisher publisher;

    public Application(IEventDispatcher eventDispatcher, IPublisher publisher)
    {
        this.eventDispatcher = eventDispatcher;

        this.publisher = publisher;
    }

    public void Run()
    {
        TestCSharpEvent();

        Console.WriteLine();

        TestObserver();

        Console.WriteLine();

        TestEventDispatcher();
    }

    private void TestObserver()
    {
        Console.WriteLine("Test Observer");

        publisher.Subscribe(new PlusSubscriber());

        publisher.Subscribe(new MultiplySubscriber());

        publisher.NotifySubscribers(new EventContext { Id = 3 });
    }

    private void TestEventDispatcher()
    {
        Console.WriteLine("Test EventDispatcher");

        var countEvent = new CountEvent { Id = 1 };

        this.eventDispatcher.Dispatch(countEvent);
    }

    private void TestCSharpEvent()
    {
        Console.WriteLine("Test CSharp Event");

        var csharpEventIllustrator = new CSharpEventIllustrator();

        csharpEventIllustrator.CalcEvent += (sender, eventArgs) => { Console.WriteLine($"CSharpEvent handle event: {eventArgs.Id}"); };

        csharpEventIllustrator.CalcEvent += (sender, eventArgs) => { Console.WriteLine($"CSharpEvent handle event: {eventArgs.Id * 2}"); };

        csharpEventIllustrator.DoACalc();
    }
}
