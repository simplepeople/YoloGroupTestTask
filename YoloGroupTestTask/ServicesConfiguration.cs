using YoloGroupTestTask.Services;

namespace YoloGroupTestTask;

public static class ServicesConfiguration
{
    public static void ConfigureServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddTransient<ICalculateHashService, CalculateHashService>();
        serviceCollection.AddTransient<IEmitNumbersService, EmitNumbersService>();
        serviceCollection.AddTransient<IInvertTextService, InvertTextViaReverseService>();
    }
}