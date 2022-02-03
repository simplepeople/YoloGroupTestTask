namespace YoloGroupTestTask.Services;

public class InvertTextViaReverseService : IInvertTextService
{
    public string InvertText(string text)
    {
        return String.Concat(text.Reverse());
    }
}