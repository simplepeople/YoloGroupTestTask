namespace YoloGroupTestTask.Models.FetchTopAssetPrices;

public record ResponseMarketCollectionType
{
    public ICollection<Market> Markets { get; init; }
}