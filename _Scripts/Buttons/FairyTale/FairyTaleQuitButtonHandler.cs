using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FairyTaleQuitButtonHandler : MonoBehaviour
{
    [SerializeField] private Button _button;

    private string _sceneName = "MainMenu";

    private void Awake()
    {
        _button.onClick.AddListener(Quit);
    }

    private void Quit()
    {
        SceneManager.LoadScene(_sceneName);
    }
}
