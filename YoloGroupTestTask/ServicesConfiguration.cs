using System.Text.Json;
using GraphQL.Client.Abstractions;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.SystemTextJson;
using YoloGroupTestTask.ApiServices.FetchTopAssetPrices;
using YoloGroupTestTask.Interfaces;
using YoloGroupTestTask.Interfaces.FetchTopAssetPrices;
using YoloGroupTestTask.Interfaces.FetchTopAssetPrices.Api;
using YoloGroupTestTask.Services;

namespace YoloGroupTestTask;

public static class ServicesConfiguration
{
    public static void ConfigureServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IInvertTextService, InvertTextViaStringBuilderService>();
        serviceCollection.AddScoped<IEmitNumbersService, EmitNumbersService>();
        serviceCollection.AddScoped<ICalculateHashService, CalculateHashService>();
        serviceCollection.ConfigureFetchTopAssetPrices();
    }

    private static void ConfigureFetchTopAssetPrices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IFetchTopAssetPricesService, FetchTopAssetPricesService>();
        serviceCollection.AddScoped<IGraphQLClient>(_ => new GraphQLHttpClient("https://api.blocktap.io/graphql",
            new SystemTextJsonSerializer(options => options.PropertyNamingPolicy = JsonNamingPolicy.CamelCase)));
        serviceCollection.AddScoped<IAssetApiService, AssetApiService>();
        serviceCollection.AddScoped<IMarketApiService, MarketApiService>();
    }
}