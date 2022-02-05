namespace YoloGroupTestTask.Models.FetchTopAssetPrices;

public record Asset
{
    public string AssetName { get; init; }
    public string AssetSymbol { get; init; }
    public long? MarketCap { get; init; }
}