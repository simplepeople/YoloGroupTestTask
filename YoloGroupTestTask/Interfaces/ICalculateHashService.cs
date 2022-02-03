namespace YoloGroupTestTask.Services;

public interface ICalculateHashService
{
    /// <summary>
    /// Probably here we should add a lot of check of file exists and
    /// try/catch blocks in case of errors 
    /// </summary>
    /// <returns></returns>
    Task<string> CalculateHash();
}