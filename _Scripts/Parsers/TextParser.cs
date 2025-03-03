using System.Collections.Generic;
using System.IO;

public static class TextParser
{
    public static string[] GetParsedText(string file, string language)
    {
        string text = File.ReadAllText($"Assets/Resources/Content/{language}/Texts/{file}.txt");      
        string[] splittedText = text.Split('$');

        List<string> result = new List<string>();

        foreach (string sentence in splittedText)
        {
            result.Add(sentence);
        }

        return result.ToArray();
    }
}
