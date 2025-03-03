using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LanguageSetter : MonoBehaviour
{
    [SerializeField] private Button _button;

    [SerializeField] private TextMeshProUGUI[] _texts;

    private Dictionary<string, string> _englishLanguage = new Dictionary<string, string>
    {
        { "KidsName" , "Kid's name" },
        { "Language" ,  "Language" }
    };
    private Dictionary<string, string> _russianLanguage = new Dictionary<string, string>
    {
        { "KidsName" , "»м€ малыша" },
        { "Language" ,  "язык" }
    };

    private void Awake()
    {
        _button.onClick.AddListener(SetLanguage);
        _button.onClick.AddListener(ChangeButtonsContent);
    }

    private void ChangeButtonsContent()
    {
        for (int i = 0; i < _texts.Length; i++)
        {
            switch (BookData.Language)
            {
                case "English":
                    _texts[i].text = _englishLanguage[_texts[i].name];
                    break;
                case "Russian":
                    _texts[i].text = _russianLanguage[_texts[i].name];
                    break;
            }          
        }
    }

    private void SetLanguage()
    {
        BookData.Language = name;
    }
}