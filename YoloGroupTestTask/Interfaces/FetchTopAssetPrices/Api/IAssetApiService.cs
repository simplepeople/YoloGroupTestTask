using YoloGroupTestTask.Models.FetchTopAssetPrices;

namespace YoloGroupTestTask.Interfaces.FetchTopAssetPrices.Api;

public interface IAssetApiService
{
    public Task<ICollection<Asset>> GetAllAssets();
}