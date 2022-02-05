using GraphQL;
using GraphQL.Client.Abstractions;
using YoloGroupTestTask.Interfaces.FetchTopAssetPrices.Api;
using YoloGroupTestTask.Models.FetchTopAssetPrices;

namespace YoloGroupTestTask.ApiServices.FetchTopAssetPrices;

public class AssetApiService : BaseGraphQlApiService, IAssetApiService
{
    public AssetApiService(IGraphQLClient client) : base(client)
    {
    }

    public async Task<ICollection<Asset>> GetAllAssets()
    {
        var query = new GraphQLRequest
        {
            Query = @"
                query PageAssets {
                    assets(sort: [{marketCapRank: ASC}]) {
                        assetName
                        assetSymbol
                        marketCap
                    }
                }"
        };
        var response = await Client.SendQueryAsync<ResponseAssetCollectionType>(query);
        return response.Data.Assets;
    }
}