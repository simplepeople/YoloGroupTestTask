using System.Text;
using YoloGroupTestTask.Interfaces;

namespace YoloGroupTestTask.Services;

public class InvertTextViaStringBuilderService : IInvertTextService
{
    public string InvertText(string text)
    {
        var sb = new StringBuilder(text.Length);
        for (int i = text.Length - 1; i > 0; i--)
        {
            sb.Append(text[i]);
        }

        return sb.ToString();
    }
}