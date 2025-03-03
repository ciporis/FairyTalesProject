using TMPro;
using UnityEngine;

public class ContentManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI[] _texts;
    private void Awake()
    {
        BookData.Language = "Russian";
    }
}

public class ButtonsContent
{
    public string Text;
}
