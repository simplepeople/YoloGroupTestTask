using GraphQL.Client.Abstractions;

namespace YoloGroupTestTask.ApiServices.FetchTopAssetPrices;

public abstract class BaseGraphQlApiService
{
    protected readonly IGraphQLClient Client;

    protected BaseGraphQlApiService(IGraphQLClient client)
    {
        Client = client;
    }
}