using System.Diagnostics;

namespace YoloGroupTestTask.Services;

public class EmitNumbersService : IEmitNumbersService
{
    public async Task<bool> EmitData()
    {
        var consumingResultsTasks = Enumerable.Range(0, 1000).AsParallel().Select(ConsumeData).AsSequential().ToList();
        var consumingResults = await Task.WhenAll(consumingResultsTasks);
        return consumingResults.All(consumingResult => consumingResult);
    }

    /// <summary>
    /// If we imagine that we have separate producing/consuming services then it's better to divide them
    /// on component level and transfer the data via MQ. Especially if we need to do a lot of CPU-intensive operations
    /// with unpredicted amount of requests and related horizontal autoscaling. Then, depending on avg time of typical
    /// operation execution and amount of clients, we also able to change direct request/response model to polling 
    /// </summary>
    /// <param name="data"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    
    private async Task<bool> ConsumeData<T>(T data)
    {
        const int pause = 100;
        await Task.Delay(pause);
        Debug.WriteLine(data?.ToString());
        return true;
    }
}