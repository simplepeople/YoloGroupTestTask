using YoloGroupTestTask.Models.FetchTopAssetPrices;

namespace YoloGroupTestTask.Interfaces.FetchTopAssetPrices.Api;

public interface IMarketApiService
{
    public Task<ICollection<Market>> GetMarkets(IEnumerable<string> baseSymbols);
}