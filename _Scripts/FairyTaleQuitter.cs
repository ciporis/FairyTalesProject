using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FairyTaleQuitter : MonoBehaviour
{
    [SerializeField] private Button _button;

    private void Start()
    {
        _button.onClick.AddListener(Quit);
    }

    private void Quit()
    {
        SceneManager.LoadScene(1);
    }
}
