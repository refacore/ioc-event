// See https://aka.ms/new-console-template for more information
using Events;
using Events.EventDispatcher;
using Events.Observer;
using Microsoft.Extensions.DependencyInjection;

Console.WriteLine("Hello, World!");

var services = new ServiceCollection();

services.AddSingleton<IEventDispatcher, Dispatcher>();

services.AddTransient<IEventHandler<CountEvent>, CountEventHandler>();

services.AddTransient<IEventHandler<CountEvent>, DoubleCountEventHandler>();

services.AddTransient<IPublisher, Publisher>();

services.AddTransient<Application>();

var serviceProvider = services.BuildServiceProvider();

var app = serviceProvider.GetRequiredService<Application>();

app.Run();
