using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class BookManager : MonoBehaviour
{
    public List<string> Sentences = new List<string>();
    public int PagesCount;
    public string TxtFileName;


    private void Start()
    {
        ParceFile(TxtFileName);
    }

    private void ParceFile(string txtFileName)
    {
        string fileText = File.ReadAllText($"Assets/Resources/Texts/{txtFileName}.txt");

        char[] separators = { '?' , '.', '!' };

        string[] splittedText = fileText.Split(separators);

        for (int i = 0; i < splittedText.Length; i+=2)
        {
            try
            {
                Sentences.Add(splittedText[i] + "." + splittedText[i + 1]);
            }
            catch
            {
                Sentences.Add(splittedText[i] + ".");
            }
        }
    }   
}
