using GraphQL;
using GraphQL.Client.Abstractions;
using YoloGroupTestTask.Interfaces.FetchTopAssetPrices.Api;
using YoloGroupTestTask.Models.FetchTopAssetPrices;

namespace YoloGroupTestTask.ApiServices.FetchTopAssetPrices;

public class MarketApiService : BaseGraphQlApiService, IMarketApiService
{
    public MarketApiService(IGraphQLClient client) : base(client)
    {
    }

    public async Task<ICollection<Market>> GetMarkets(IEnumerable<string> baseSymbols)
    {
        var query = new GraphQLRequest
        {
            Query = @"
            query price ($baseSymbols: [String!]) {
                markets(filter:
                    {baseSymbol: {_in: $baseSymbols},
                     quoteSymbol: {_eq: ""EUR"" },
                    exchangeSymbol: {_eq: ""Binance""}}) {
                marketSymbol
                    ticker {
                        lastPrice
                    }
                }
            }",
            Variables = new { baseSymbols },
        };
        var response = await Client.SendQueryAsync<ResponseMarketCollectionType>(query);
        return response.Data.Markets;
    }
}