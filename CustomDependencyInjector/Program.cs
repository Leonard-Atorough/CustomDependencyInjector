using CustomDependencyInjector;
using CustomDependencyInjector.DependencyInjection;

internal class Program
{
    private static void Main(string[] args)
    {
        var services = new DIServiceCollection();

        services.RegisterSingleton<RandomGuidGenerator>();
        //services.RegisterSingleton(new RandomGuidGenerator());

        var container = services.GenerateContainer();

        var serviceFirst = container.GetService<RandomGuidGenerator>();
        var serviceSecond = container.GetService<RandomGuidGenerator>();


        Console.WriteLine(serviceFirst.RandomGuid);
        Console.WriteLine(serviceSecond.RandomGuid);
    }
}