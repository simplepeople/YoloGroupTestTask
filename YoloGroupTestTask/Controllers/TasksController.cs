using Microsoft.AspNetCore.Mvc;
using YoloGroupTestTask.Services;

namespace YoloGroupTestTask.Controllers;

/// <summary>
/// This controller unifies endpoints for different actions. Since we don't have an understanding of
/// subject area, it's hard to follow REST principles 
/// </summary>
[ApiController]
[Route("[controller]")]
public class TasksController : ControllerBase
{
    private readonly IEmitNumbersService _emitNumbersService;
    private readonly IInvertTextService _invertTextService;
    private readonly ICalculateHashService _calculateHashService;

    public TasksController(IEmitNumbersService emitNumbersService, IInvertTextService invertTextService,
        ICalculateHashService calculateHashService)
    {
        _emitNumbersService = emitNumbersService;
        _invertTextService = invertTextService;
        _calculateHashService = calculateHashService;
    }

    [HttpPost(Name = "InvertText")]
    public string InvertText(string text)
    {
        return _invertTextService.InvertText(text);
    }

    [HttpPost(Name = "EmitData")]
    public async Task<bool> EmitData()
    {
        return await _emitNumbersService.EmitData();
    }

    [HttpPost(Name = "CalculateHash")]
    public async Task<string> CalculateHash()
    {
        return await _calculateHashService.CalculateHash();
    }

    [HttpPost(Name = "FetchTopAssetPrices")]
    public async Task<IEnumerable<int>> FetchTopAssetPrices()
    {
        return null;
    }
}