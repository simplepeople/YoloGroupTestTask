using YoloGroupTestTask.Interfaces.FetchTopAssetPrices;
using YoloGroupTestTask.Interfaces.FetchTopAssetPrices.Api;
using YoloGroupTestTask.Models.FetchTopAssetPrices;

namespace YoloGroupTestTask.Services;

public class FetchTopAssetPricesService : IFetchTopAssetPricesService
{
    private readonly IAssetApiService _assetApiService;
    private readonly IMarketApiService _marketApiService;

    public FetchTopAssetPricesService(IAssetApiService assetApiService, IMarketApiService marketApiService)
    {
        _assetApiService = assetApiService;
        _marketApiService = marketApiService;
    }

    public async Task<ICollection<PriceResult>> FetchTopAssetPrices()
    {
        const int topAssetsCount = 100;
        const int assetsPerRequestCount = 20;
        var assets = await _assetApiService.GetAllAssets();
        var topAssetsSymbolCollection =
            assets.Take(topAssetsCount).Select(asset => asset.AssetSymbol).Chunk(assetsPerRequestCount);
        var marketTasks =
            topAssetsSymbolCollection.Select(topAssetsSymbols => _marketApiService.GetMarkets(topAssetsSymbols));
        var marketCollections = await Task.WhenAll(marketTasks);
        //not sure that missing prices is ok, but it hasn't described in document
        //so we can just ignore it for now
        var prices = marketCollections.SelectMany(markets => markets)
            .Select(market => new PriceResult
            {
                MarketSymbol = market.MarketSymbol,
                //better way here is to parse price on deserialization, but to define proper .NET type
                //and converter (probably custom) we must be sure about presented type
                Price = Decimal.Parse(market.Ticker.LastPrice)
            }).ToArray();
        return prices;
    }
}