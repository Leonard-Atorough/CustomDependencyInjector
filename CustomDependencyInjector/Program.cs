using CustomDependencyInjector;
using CustomDependencyInjector.DependencyInjection;

internal class Program
{
    private static void Main(string[] args)
    {
        var services = new DIServiceCollection();

        services.RegisterSingleton<RandomGuidGenerator>();
        //services.RegisterSingleton(new RandomGuidGenerator());
        services.RegisterTransient<ISomeService, SomeServiceOne>();
        services.RegisterSingleton<IRandomGuidProvider, RandomGuidProvider>();

        var container = services.GenerateContainer();

        var serviceFirst = container.GetService<ISomeService>();
        var serviceSecond = container.GetService<ISomeService>();


        serviceFirst.PrintSomething();
        serviceSecond.PrintSomething();
    }
}