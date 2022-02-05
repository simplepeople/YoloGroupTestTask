using YoloGroupTestTask.Models.FetchTopAssetPrices;

namespace YoloGroupTestTask.Interfaces.FetchTopAssetPrices;

public interface IFetchTopAssetPricesService
{
    Task<ICollection<PriceResult>> FetchTopAssetPrices();
}