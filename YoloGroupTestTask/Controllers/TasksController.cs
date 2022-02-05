using Microsoft.AspNetCore.Mvc;
using YoloGroupTestTask.Interfaces;
using YoloGroupTestTask.Interfaces.FetchTopAssetPrices;
using YoloGroupTestTask.Models.FetchTopAssetPrices;

namespace YoloGroupTestTask.Controllers;

/// <summary>
/// This controller unifies endpoints for different actions. Since we don't have an understanding of
/// subject area, it's hard to follow REST principles 
/// </summary>
[ApiController]
[Route("api/v1/[controller]/[action]")]
public class TasksController : ControllerBase
{
    private readonly ICalculateHashService _calculateHashService;
    private readonly IEmitNumbersService _emitNumbersService;
    private readonly IFetchTopAssetPricesService _fetchTopAssetPricesService;
    private readonly IInvertTextService _invertTextService;

    public TasksController(IEmitNumbersService emitNumbersService, IInvertTextService invertTextService,
        ICalculateHashService calculateHashService, IFetchTopAssetPricesService fetchTopAssetPricesService)
    {
        _emitNumbersService = emitNumbersService;
        _invertTextService = invertTextService;
        _calculateHashService = calculateHashService;
        _fetchTopAssetPricesService = fetchTopAssetPricesService;
    }

    [HttpPost(Name = "InvertText")]
    public string InvertText([FromBody] string text)
    {
        return _invertTextService.InvertText(text);
    }

    [HttpPost(Name = "EmitData")]
    public async Task<bool> EmitData()
    {
        return await _emitNumbersService.EmitData();
    }

    /// <summary>
    /// Calculate hash of single file from Assets/CalculateHash folder
    /// We can extend this method in future and allow passing a link to processed file or file itself
    /// </summary>
    /// <returns></returns>
    [HttpPost(Name = "CalculateHash")]
    public async Task<string> CalculateHash()
    {
        return await _calculateHashService.CalculateHash();
    }

    [HttpPost(Name = "FetchTopAssetPrices")]
    public async Task<ICollection<PriceResult>> FetchTopAssetPrices()
    {
        return await _fetchTopAssetPricesService.FetchTopAssetPrices();
    }
}