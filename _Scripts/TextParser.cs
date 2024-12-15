using System.Collections.Generic;
using System.IO;
using System.Threading;

public static class TextParser
{
    public static string[] GetParsedText(string fileName)
    {
        string text = File.ReadAllText($"Assets/Resources/Texts/{fileName}.txt");      
        string[] splittedText = text.Split('$');

        List<string> result = new List<string>();

        foreach (string sentence in splittedText)
        {
            result.Add(sentence);
        }

        return result.ToArray();
    }
}
