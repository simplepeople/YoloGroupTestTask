namespace YoloGroupTestTask.Models.FetchTopAssetPrices;

public record ResponseAssetCollectionType
{
    public ICollection<Asset> Assets { get; init; }
}