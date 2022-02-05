namespace YoloGroupTestTask.Models.FetchTopAssetPrices;

public record Market
{
    public string MarketSymbol { get; init; }
    public Ticker Ticker { get; init; }
}